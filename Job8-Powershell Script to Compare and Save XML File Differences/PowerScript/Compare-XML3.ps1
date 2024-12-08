# Function to get the XPath of an XML node using SelectSingleNode method
function Get-NodeXPath {
    param (
        [System.Xml.XmlNode]$node
    )

    $xpathNodes = @()

    while ($node -ne $null) {
        $xpathNodes += $node.Name
        $node = $node.ParentNode
    }

    $xpathNodes = $xpathNodes | ForEach-Object { $_ } 
    return "/$($xpathNodes -join '/')"
}
# Function to recursively compare XML elements and generate differences
function Compare-XMLNodes {
    param (
        [xml]$xml1Node,
        [xml]$xml2Node,
        [xml]$xmlDiffNode
    )
Write-Host "Compare-XMLNodes "
    # Compare the node names
Write-Host "Node Name: " + $xml1Node.LocalName + $xml2Node.LocalName

    if ($xml1Node.LocalName -ne $xml2Node.LocalName) {
        $changeNode = $xmlDiffNode.CreateElement("Change")
        $changeNode.SetAttribute("Type", "Name")
Write-Host "parent: " + $xml1Node
        $xPathValue  = Get-NodeXPath $xml1Node
        $changeNode.SetAttribute("Path",$xPathValue)
        $oldValueNode = $xmlDiffNode.CreateElement("OldValue")
        $oldValueNode.InnerText = $xml1Node.LocalName
        $changeNode.AppendChild($oldValueNode)
        $newValueNode = $xmlDiffNode.CreateElement("NewValue")
        $newValueNode.InnerText = $xml2Node.LocalName
        $changeNode.AppendChild($newValueNode)
        $xmlDiffNode.DocumentElement.AppendChild($changeNode)
    }

    # Compare the attributes
    $xml1Attrs = $xml1Node.Attributes | ForEach-Object { $_.Name }
    $xml2Attrs = $xml2Node.Attributes | ForEach-Object { $_.Name }
    $allAttrs = $xml1Attrs + $xml2Attrs | Get-Unique
    foreach ($attr in $allAttrs) {
        $attrValue1 = $xml1Node.GetAttribute($attr)
        $attrValue2 = $xml2Node.GetAttribute($attr)
        if ($attrValue1 -ne $attrValue2) {
            $changeNode = $xmlDiffNode.CreateElement("Change")
            $changeNode.SetAttribute("Type", "Attribute")
Write-Host "parent: " + $xml1Node
            $xPathValue  = Get-NodeXPath $xml1Node
            $changeNode.SetAttribute("Path",$xPathValue)
            $changeNode.SetAttribute("Attribute", $attr)
            $oldValueNode = $xmlDiffNode.CreateElement("OldValue")
            $oldValueNode.InnerText = $attrValue1
            $changeNode.AppendChild($oldValueNode)
            $newValueNode = $xmlDiffNode.CreateElement("NewValue")
            $newValueNode.InnerText = $attrValue2
            $changeNode.AppendChild($newValueNode)
            $xmlDiffNode.DocumentElement.AppendChild($changeNode)
        }
    }
Write-Host "Child nodes: " + $xml1Node.ChildNodes
    # Compare child elements recursively
    foreach ($childNode in $xml1Node.ChildNodes) {
Write-Host "Child: " + $childNode
  $xPathValue  = Get-NodeXPath $childNode
        $matchingNode = $xml2Node.SelectSingleNode($xPathValue)
        if ($matchingNode -ne $null) {
            Compare-XMLNodes $childNode $matchingNode $xmlDiffNode
        } else {
            # Node not found in the second XML
            $changeNode = $xmlDiffNode.CreateElement("Change")
            $changeNode.SetAttribute("Type", "Missing")
 $xPathValue  = Get-NodeXPath $childNode
            $changeNode.SetAttribute("Path", $xPathValue )
            $xmlDiffNode.DocumentElement.AppendChild($changeNode)
        }
    }

    # Check for extra child nodes in the second XML
    foreach ($childNode in $xml2Node.ChildNodes) {
Write-Host "The value of myVariable is: $xml1Node"
$xPathValue  = Get-NodeXPath $childNode
        $matchingNode = $xml1Node.SelectSingleNode($xPathValue)
        if ($matchingNode -eq $null) {
            $changeNode = $xmlDiffNode.CreateElement("Change")
            $changeNode.SetAttribute("Type", "Added")
            $changeNode.SetAttribute("Path", $xPathValue)
            $xmlDiffNode.DocumentElement.AppendChild($changeNode)
        }
    }
}

# Function to compare two XML files and generate differences
function Compare-XMLFiles {
    param (
        [string]$filePath1,
        [string]$filePath2,
        [string]$outputFilePath
    )

    # Load XML files
    $xml1 = [xml](Get-Content $filePath1)
    $xml2 = [xml](Get-Content $filePath2)

    # Create a new XML document to store the differences
    $xmlDiff = New-Object XML
    $xmlDiff.AppendChild($xmlDiff.CreateXmlDeclaration("1.0", "UTF-8", $null))
    $rootNode = $xmlDiff.CreateElement("Differences")
    $xmlDiff.AppendChild($rootNode)

    # Start comparing the nodes
    Compare-XMLNodes $xml1 $xml2 $xmlDiff

    # Save the differences to the output file
    $xmlDiff.Save($outputFilePath)
}



# Example usage
$filePath1 = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"
$filePath2 = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"
$outputFilePath = "D:\Tariq-private\work\Job8\OutputFiles\Output.xml"

Compare-XMLFiles -filePath1 $filePath1 -filePath2 $filePath2 -outputFilePath $outputFilePath


