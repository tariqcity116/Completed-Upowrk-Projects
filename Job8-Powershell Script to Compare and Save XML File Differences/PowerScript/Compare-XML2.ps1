# Import the XML module
Import-Module XML

# Get the paths to the two XML files
$actualPath = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"
$expectedPath = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"

# Load the XML files into PowerShell objects
$actual = [xml](Get-Content $actualPath)
$expected = [xml](Get-Content $expectedPath)

# Compare the two XML objects
if ($actual -ne $expected) {
    # The two XML files are not the same
    Write-Host "The two XML files are not the same." + $actual + $expected

    # Compare the nodes in the two XML files
    foreach ($node in $actual.ChildNodes) {
 Write-Host "The two XML files are not the same. $node.Path" +  $node.Path
       #  $expectedNodes = $expected.SelectNodes($node.Path)
     #   $expectedNode = $expectedNodes.SelectSingleNode()

        # Compare the attributes in the two nodes
     #   if ($node.Attributes.Count -ne $expectedNode.Attributes.Count) {
     #       Write-Host "The number of attributes in the node '$node.Name' is different."
    #    }

Write-Host "The two XML files are not the same. $node.Attributes.Count" + $node.Attributes.Count
        for ($i = 0; $i -lt $node.Attributes.Count; $i++) {
Write-Host "The two XML files are not the same. " + $node.Attributes[$i].Name
        #    if ($node.Attributes[$i].Name -ne $expectedNode.Attributes[$i].Name) {
          #      Write-Host "The attribute name '$node.Attributes[$i].Name' is different."
         #   }

        #    if ($node.Attributes[$i].Value -ne $expectedNode.Attributes[$i].Value) {
        #        Write-Host "The attribute value for '$node.Attributes[$i].Name' is different."
       #     }
        }
    }
} else {
    # The two XML files are the same
    Write-Host "The two XML files are the same."
}


