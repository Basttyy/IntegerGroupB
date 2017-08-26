<?php
include "drugs.php";
$conn = mysqli_connect('localhost', 'root', '', 'integer');
$query= 'select * from drugs';
$result = mysqli_query($conn, $query);
$data = mysqli_fetch_all($result,MYSQLI_ASSOC);

 echo json_encode($data);

 ?>