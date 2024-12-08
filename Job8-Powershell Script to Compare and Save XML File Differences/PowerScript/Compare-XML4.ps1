# Function to recursively compare XML nodes and child nodes
function Compare-XmlNodes {
    param (
        [System.Xml.XmlNode]$node1,
        [System.Xml.XmlNode]$node2
    )

    if ($node1 -eq $null -or $node2 -eq $null) {
        return
    }

    # Compare the node names
    if ($node1.Name -ne $node2.Name) {
        Write-Host "Node Name Mismatch: $($node1.Name) vs. $($node2.Name)"
    }

    # Compare the attributes (if any)
    $node1Attrs = $node1.Attributes
    $node2Attrs = $node2.Attributes
    $allAttrs = $node1Attrs + $node2Attrs | Get-Unique
    foreach ($attr in $allAttrs) {
        $attrValue1 = $node1.GetAttribute($attr.Name)
        $attrValue2 = $node2.GetAttribute($attr.Name)
        if ($attrValue1 -ne $attrValue2) {
            Write-Host "Attribute Mismatch: $($node1.Name)\@$($attr.Name)"
            Write-Host "   - File1: $attrValue1"
            Write-Host "   - File2: $attrValue2"
        }
    }

    # Compare child nodes recursively
    $node1ChildNodes = $node1.ChildNodes
    $node2ChildNodes = $node2.ChildNodes

    if ($node1ChildNodes.Count -ne $node2ChildNodes.Count) {
        Write-Host "Child Nodes Count Mismatch: $($node1.Name) - File1: $($node1ChildNodes.Count), File2: $($node2ChildNodes.Count)"
    }

    $minChildCount = [Math]::Min($node1ChildNodes.Count, $node2ChildNodes.Count)

    for ($i = 0; $i -lt $minChildCount; $i++) {
        $node1Child = $node1ChildNodes[$i]
        $node2Child = $node2ChildNodes[$i]

        Compare-XmlNodes $node1Child $node2Child
    }
}

# Function to create a new XML file with the differences
function Create-XmlDiffFile {
    param (
        [string]$outputFilePath,
        [string]$nodeName,
        [string]$attributeName,
        [string]$oldValue,
        [string]$newValue
    )

    $xmlDoc = New-Object System.Xml.XmlDocument
    $xmlDoc.AppendChild($xmlDoc.CreateXmlDeclaration("1.0", $null, $null))

    $rootNode = $xmlDoc.CreateElement("Differences")
    $xmlDoc.AppendChild($rootNode)

    $diffNode = $xmlDoc.CreateElement("Difference")
    $rootNode.AppendChild($diffNode)

    $nodeNameAttr = $xmlDoc.CreateAttribute("NodeName")
    $nodeNameAttr.Value = $nodeName
    $diffNode.Attributes.Append($nodeNameAttr)

    $attrNameAttr = $xmlDoc.CreateAttribute("AttributeName")
    $attrNameAttr.Value = $attributeName
    $diffNode.Attributes.Append($attrNameAttr)

    $oldValueNode = $xmlDoc.CreateElement("OldValue")
    $oldValueNode.InnerText = $oldValue
    $diffNode.AppendChild($oldValueNode)

    $newValueNode = $xmlDoc.CreateElement("NewValue")
    $newValueNode.InnerText = $newValue
    $diffNode.AppendChild($newValueNode)

    $xmlDoc.Save($outputFilePath)
}

# Function to compare two XML files and display the differences
function Compare-XmlFiles {
    param (
        [string]$filePath1,
        [string]$filePath2
    )

    $xmlDocument1 = New-Object System.Xml.XmlDocument
    $xmlDocument1.Load($filePath1)

    $xmlDocument2 = New-Object System.Xml.XmlDocument
    $xmlDocument2.Load($filePath2)

    Compare-XmlNodes $xmlDocument1.DocumentElement $xmlDocument2.DocumentElement
}

# Example usage
$filePath1 = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"
$filePath2 = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"

Compare-XmlFiles -filePath1 $filePath1 -filePath2 $filePath2


