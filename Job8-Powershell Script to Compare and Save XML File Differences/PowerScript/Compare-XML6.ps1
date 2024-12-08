function Compare-XmlFilesAndSaveDifferences {
    param (
        [string]$filePath1,
        [string]$filePath2,
        [string]$outputFilePath
    )

    # Load the System.Web assembly to use HtmlDecode() method
    Add-Type -AssemblyName System.Web

    # Load the XML files
    $xml1 = New-Object -TypeName System.Xml.XmlDocument
    $xml2 = New-Object -TypeName System.Xml.XmlDocument
    $xml1.Load($filePath1)
    $xml2.Load($filePath2)

    # Compare the XML nodes
    $differences = @()

    Compare-XmlNodes $xml1.DocumentElement $xml2.DocumentElement ([string]::Empty) ([ref]$differences)

    # Create a new XML document to store the differences
    $outputXml = New-Object -TypeName System.Xml.XmlDocument

    # Create the root node for differences
    $rootNode = $outputXml.CreateElement("Changes")
    $outputXml.AppendChild($rootNode)

    # Add the differences to the new XML document
    foreach ($diff in $differences) {
        $nodePath = $diff.NodePath
        $attrName = $diff.AttributeName
        $oldValue = $diff.OldValue
        $newValue = $diff.NewValue




        # Create a new node for each difference
        $diffNode = $outputXml.CreateElement("Change")
        $rootNode.AppendChild($diffNode)

        # Add attributes to the difference node
        $pathAttr = $outputXml.CreateAttribute("Path")
        $pathAttr.Value = $nodePath
        $diffNode.Attributes.Append($pathAttr)

        if ($attrName -ne "") {
            $attrAttr = $outputXml.CreateAttribute("Attribute")
            $attrAttr.Value = $attrName
            $diffNode.Attributes.Append($attrAttr)
        }

        # Add old and new values as child nodes of the difference node
        $oldValueNode = $outputXml.CreateAttribute("OldValue")
        $oldValueNode.Value = $oldValue
        $diffNode.Attributes.Append($oldValueNode)

        $newValueNode = $outputXml.CreateAttribute("NewValue")
        $newValueNode.Value = $newValue
        $diffNode.Attributes.Append($newValueNode)
    }

    # Save the output XML to the specified file
    $outputXml.Save($outputFilePath)
}



function Compare-XmlNodes {
    param (
        [System.Xml.XmlNode]$node1,
        [System.Xml.XmlNode]$node2,
        [string]$currentPath,
        [ref]$differencesArray
    )

    if ($node1 -eq $null -or $node2 -eq $null) {
        return
    }

    # Build the full path of the current node
    $currentPath = if ($currentPath -eq "") { $node1.Name } else { "$currentPath\$($node1.Name)" }
Write-Host "current path: " + $currentPath
    # Check if node2 has a corresponding node for the currentPath in node1
    $matchingNode = $node2.SelectSingleNode($currentPath)
Write-Host "matching: " + $matchingNode

    if ($matchingNode -eq $null) {
Write-Host "difference: " + $currentPath

        $difference = @{
            NodePath = $currentPath
            AttributeName = ""
            OldValue = ""
            NewValue = [System.Web.HttpUtility]::HtmlDecode($node1.OuterXml)
        }
        $differencesArray.Value += $difference
    }

    # Compare the attributes (if any)
    $node1Attrs = $node1.Attributes
    $node2Attrs = $matchingNode.Attributes

    if ($node1Attrs -and $node2Attrs) {
        $allAttrs = $node1Attrs + $node2Attrs | Get-Unique

        foreach ($attr in $allAttrs) {
            $attrValue1 = $node1.GetAttribute($attr.Name)
            $attrValue2 = $matchingNode.GetAttribute($attr.Name)

            if ($attrValue1 -ne $attrValue2) {
                $difference = @{
                    NodePath = $currentPath
                    AttributeName = $attr.Name
                    OldValue = $attrValue1
                    NewValue = $attrValue2
 OldNode = $node1
           NewNode = $node2
           OldPath = $oldPath
           NewPath = $newPath
                }
                $differencesArray.Value += $difference
            }
        }
    }

    # Compare child nodes recursively
    $node1ChildNodes = $node1.ChildNodes

    foreach ($node1Child in $node1ChildNodes) {
        Compare-XmlNodes $node1Child $node2 $currentPath $differencesArray
    }
}


# File paths for the XML files to compare
$filePath1 = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"
$filePath2 = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"

# Output file path for saving the differences
$outputFilePath = "D:\Tariq-private\work\Job8\OutputFiles\Output.xml"

# Compare the XML files and save the differences to the output file
Compare-XmlFilesAndSaveDifferences -filePath1 $filePath1 -filePath2 $filePath2 -outputFilePath $outputFilePath
