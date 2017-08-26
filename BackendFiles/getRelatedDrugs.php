<?php
include "drugs.php";
$conn = mysqli_connect('localhost', 'root', '', 'integer');
$name= $_GET['id'];

$drugQuery="SELECT * FROM drugs WHERE name = '" . $name ."'";
 $drugResult=mysqli_query($conn, $drugQuery);
 $drugData = mysqli_fetch_assoc($drugResult); 
 $drug_id= $drugData['id'];

 $query= "SELECT * FROM drug_disease WHERE drug_id = '" . $drug_id ."'";
 $result = mysqli_query($conn, $query);
 $data = mysqli_fetch_assoc($result); 
 $disease_id= $data['disease_id'];

 $disease_query ="SELECT d.name,e.drug_id FROM drug_disease AS e JOIN drugs as d on e.drug_id =d.id WHERE 
 e.disease_id = '" . $disease_id ."'". "and e.drug_id != '".  $drug_id ."'";
 $queryResult = mysqli_query($conn, $disease_query);
$queryData = mysqli_fetch_all($queryResult,MYSQLI_ASSOC);
echo json_encode($queryData);

 ?>