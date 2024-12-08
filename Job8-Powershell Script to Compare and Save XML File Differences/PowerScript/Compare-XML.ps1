# Load the System.Web assembly
Add-Type -AssemblyName System.Web

# Function to recursively compare XML nodes and child nodes
function Compare-XmlNodes {
    param (
        [System.Xml.XmlNode]$node1,
        [System.Xml.XmlNode]$node2,
        [ref]$differencesArray
    )

   if ($node1 -eq $null -or $node2 -eq $null) {
      
# Build the full path of the old node
    $oldPath = if ($oldPath -eq "") { $node1.Name } else { "$oldPath\$($node1.Name)" }

# Build the full path of the new node
    $newPath = if ($newPath -eq "") { $node2.Name } else { "$newPath\$($node2.Name)" }

# Compare the node values
    if ($node1.InnerText -ne $node2.InnerText) {
        $difference = @{
            NodeName = $node1.Name
            AttributeName = ""
            OldValue = $node1.InnerText
            NewValue = $node2.InnerText
           OldNode = $node1
           NewNode = $node2
           OldPath = $oldPath
           NewPath = $newPath
        }
      $differencesArray.Value += $difference
    }


    # Compare the node names
   
        $difference = @{
            NodeName = $node1.Name
            AttributeName = ""
            OldValue = ""
            NewValue = ""
           OldNode = $node1
           NewNode = $node2
           OldPath = $oldPath
           NewPath = $newPath
        }

        
$differencesArray.Value += $difference
 

    # Compare the attributes (if any)
 if($node1 -ne $null)
{
    $node1Attrs = $node1.Attributes
}
 if($node2 -ne $null)
{
    $node2Attrs = $node2.Attributes
}
    $allAttrs = $node1Attrs + $node2Attrs | Get-Unique
    foreach ($attr in $allAttrs) {
 if($node1 -ne $null)
{
        $attrValue1 = $node1.GetAttribute($attr.Name)
}
 if($node2 -ne $null)
{
        $attrValue2 = $node2.GetAttribute($attr.Name)
}
       
            $difference = @{
                NodeName = $node1.Name
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

    # Compare child nodes recursively
    $node1ChildNodes = $node1.ChildNodes
    $node2ChildNodes = $node2.ChildNodes



   
        $difference = @{
            NodeName = $node1.Name
            AttributeName = "ChildNodesCount"
            OldValue = $node1ChildNodes.Count.ToString()
            NewValue = $node2ChildNodes.Count.ToString()
        }
       $differencesArray.Value += $difference
 

    $minChildCount = [Math]::Max($node1ChildNodes.Count, $node2ChildNodes.Count)

    for ($i = 0; $i -lt $minChildCount; $i++) {
     if($node1 -ne $null)
{
  $node1Child = $node1ChildNodes[$i]
}
      
    if($node2 -ne $null)
{
 $node2Child = $node2ChildNodes[$i]
}
       

        Compare-XmlNodes $node1Child $node2Child $differencesArray
    }

    }
else{

# Build the full path of the old node
    $oldPath = if ($oldPath -eq "") { $node1.Name } else { "$oldPath\$($node1.Name)" }

# Build the full path of the new node
    $newPath = if ($newPath -eq "") { $node2.Name } else { "$newPath\$($node2.Name)" }


# Compare the node values
    if ($node1.InnerText -ne $node2.InnerText) {
        $difference = @{
            NodeName = $node1.Name
            AttributeName = ""
            OldValue = $node1.InnerText
            NewValue = $node2.InnerText
           OldNode = $node1
           NewNode = $node2
           OldPath = $oldPath
           NewPath = $newPath
        }
      $differencesArray.Value += $difference
    }



    # Compare the node names
    if ($node1.Name -ne $node2.Name) {
        $difference = @{
            NodeName = $node1.Name
            AttributeName = ""
            OldValue = ""
            NewValue = ""
           OldNode = $node1
           NewNode = $node2
           OldPath = $oldPath
           NewPath = $newPath
        }
      $differencesArray.Value += $difference
    }

 

    # Compare the attributes (if any)
    $node1Attrs = $node1.Attributes
    $node2Attrs = $node2.Attributes
    $allAttrs = $node1Attrs + $node2Attrs | Get-Unique
    foreach ($attr in $allAttrs) {
        $attrValue1 = $node1.GetAttribute($attr.Name)
        $attrValue2 = $node2.GetAttribute($attr.Name)
        if ($attrValue1 -ne $attrValue2) {
            $difference = @{
                NodeName = $node1.Name
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

    # Compare child nodes recursively
    $node1ChildNodes = $node1.ChildNodes
    $node2ChildNodes = $node2.ChildNodes

Write-Host "old Nodes: " + $oldPath
Write-Host "new Nodes: " + $newPath
Write-Host " old Number of Nodes: " + $node1ChildNodes.Count
Write-Host "new Number of Nodes: " + $node2ChildNodes.Count

    if ($node1ChildNodes.Count -ne $node2ChildNodes.Count) {
        $difference = @{
            NodeName = $node1.Name
            AttributeName = "ChildNodesCount"
            OldValue = $node1ChildNodes.Count.ToString()
            NewValue = $node2ChildNodes.Count.ToString()
        }
    $differencesArray.Value += $difference
    }

    $minChildCount = [Math]::Max($node1ChildNodes.Count, $node2ChildNodes.Count)

Write-Host "Number of Nodes: " + $minChildCount

    for ($i = 0; $i -lt $minChildCount; $i++) {
        $node1Child = $node1ChildNodes[$i]
        $node2Child = $node2ChildNodes[$i]

        Compare-XmlNodes $node1Child $node2Child $differencesArray
    }
}

}

# Function to create a new XML file with the differences
function Create-XmlDiffFile {
    param (
        [string]$outputFilePath,
        [array]$differences
    )

    $xmlDoc = New-Object System.Xml.XmlDocument
    $xmlDoc.AppendChild($xmlDoc.CreateXmlDeclaration("1.0", $null, $null))

    $rootNode = $xmlDoc.CreateElement("Changes")
    $xmlDoc.AppendChild($rootNode)
 $differencesArrayNew = [System.Collections.ArrayList]::new()
 foreach ($diff in $differences) {
$IsAvailable =  InsertDifferences -difference $diff -differences $differencesArrayNew
if($IsAvailable -eq "No")
{
 $differencesArrayNew += $diff
}
}

    foreach ($diff in $differencesArrayNew) {
Write-Host "nodename1: " + $diff.NodeName
     if($diff.NewPath -ne $null -and  $diff.NewPath -ne "")
{
 if($diff.OldValue -eq "" -and  $diff.NewValue -eq "" -and  $diff.AttributeName -eq "")
{

}else{
$diffNode = $xmlDoc.CreateElement("Change")
        $rootNode.AppendChild($diffNode)

$Type = "AttributeChanged"
 if($diff.OldValue -ne $null)
{
$Path = $diff.OldPath
}


 if($diff.NewPath -ne $null)
{
$Path = $diff.NewPath
}

 if($diff.OldValue -eq $null)
{
$Type = "NodeAdded"
$Path = $diff.NewPath
}

 if($diff.NewValue -eq $null)
{
$Type = "NodeDeleted"

$Path = $diff.OldPath
}

     

       $TypeAttr = $xmlDoc.CreateAttribute("Type")
        $TypeAttr.Value = $Type
        $diffNode.Attributes.Append($TypeAttr)

        $nodeNameAttr = $xmlDoc.CreateAttribute("FullPath")
        $nodeNameAttr.Value = $Path
        $diffNode.Attributes.Append($nodeNameAttr)

        $attrNameAttr = $xmlDoc.CreateAttribute("AttributeName")
        $attrNameAttr.Value = $diff.AttributeName
        $diffNode.Attributes.Append($attrNameAttr)

        $oldValueAttr = $xmlDoc.CreateAttribute("OldValue")
        $oldValueAttr.Value = [System.Web.HttpUtility]::HtmlDecode($diff.OldValue)
        $diffNode.Attributes.Append($oldValueAttr)

        $newValueAttr = $xmlDoc.CreateAttribute("NewValue")
        $newValueAttr.Value = [System.Web.HttpUtility]::HtmlDecode($diff.NewValue)
        $diffNode.Attributes.Append($newValueAttr)
}
}



        
    }

    $xmlDoc.Save($outputFilePath)
}

# Function to check element exist or not
function  InsertDifferences{
 param (
        [object]$difference,
        [array]$differences    
    )

$isAvailable = "No"
Write-Host "difference1: " +  $difference.NodeName + $difference.AttributeName + $difference.OldValue+ $difference.NewValue
foreach ($attr in $differences  ) {
Write-Host "document1: " +  $attr.NodeName + $attr.AttributeName + $attr.OldValue+ $attr.NewValue

  if(  $attr.NodeName -eq $difference.NodeName  -and   $attr.AttributeName -eq $difference.AttributeName -and   $attr.OldValue -eq $difference.OldValue -and   $attr.NewValue -eq $difference.NewValue)
{

$isAvailable = "Yes"
}

}

return $isAvailable


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

    $differencesArray = [System.Collections.ArrayList]::new()
Write-Host "document: " + $xmlDocument1.DocumentElement + $xmlDocument2.DocumentElement
    Compare-XmlNodes $xmlDocument1.DocumentElement $xmlDocument2.DocumentElement ([ref]$differencesArray)

    Create-XmlDiffFile -outputFilePath "D:\Tariq-private\work\Job8\OutputFiles\Output.xml" -differences $differencesArray
}

# Example usage
$filePath1 = "D:\Tariq-private\work\Job8\OrignalFiles\originalFile.xml"
$filePath2 = "D:\Tariq-private\work\Job8\OrignalFiles\newFile.xml"

Compare-XmlFiles -filePath1 $filePath1 -filePath2 $filePath2



