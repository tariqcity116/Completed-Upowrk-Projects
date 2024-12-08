# Set the paths to the two XML files to compare
$sourceXmlPath = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"
$targetXmlPath = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"

# Load the XML contents from the files
$sourceXml = [xml](Get-Content -Path $sourceXmlPath)
$targetXml = [xml](Get-Content -Path $targetXmlPath)

# Create a new XML document to hold the differences
$newXmlDoc = New-Object -TypeName System.Xml.XmlDocument

# Function to compare child nodes recursively
function Compare-XmlNodes {
    param ($sourceNode, $targetNodes, $parentNode)

    foreach ($sourceChild in $sourceNode.ChildNodes) {
        $targetChild = $targetNodes | Where-Object { $_.Name -eq $sourceChild.Name }

        if ($targetChild -eq $null) {
            # Node not found in the target, create a new difference node
            $diffNode = $newXmlDoc.CreateElement("Difference")
            $diffNode.SetAttribute("Node", $sourceChild.Name)
            $diffNode.SetAttribute("Status", "Missing in Target")
            $parentNode.AppendChild($diffNode)
        }
        elseif ($targetChild.Count -eq 1) {
            # Single matching node found, compare the values
            $targetChild = $targetChild[0]

            if ($sourceChild.InnerText -ne $targetChild.InnerText) {
                # Node values are different, create a new difference node
                $diffNode = $newXmlDoc.CreateElement("Difference")
                $diffNode.SetAttribute("Node", $sourceChild.Name)
                $diffNode.SetAttribute("Status", "Different Values")
                $diffNode.SetAttribute("SourceValue", $sourceChild.InnerText)
                $diffNode.SetAttribute("TargetValue", $targetChild.InnerText)
                $parentNode.AppendChild($diffNode)
            }
        }
        else {
            # Multiple matching nodes found in the target, handle as required
            # You may choose to add further logic here depending on your use case
        }

        # Recursively compare child nodes
        Compare-XmlNodes $sourceChild $targetNodes $diffNode
    }
}

# Start the comparison with the root nodes
$matchingTargetNodes = $targetXml.SelectNodes($sourceXml.DocumentElement.Name)
Compare-XmlNodes $sourceXml.DocumentElement $matchingTargetNodes $newXmlDoc

# Save the new XML file with the differences
$newXmlPath = "D:\Tariq-private\work\Job8\OutputFiles\Output.xml"
$newXmlDoc.Save($newXmlPath)

Write-Host "Differences between the two XML files have been saved to: $newXmlPath"


