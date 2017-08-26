<?php
	
	class connection{
		private $servername = "localhost";
		private $username = "root";
		private $password = "";
		private $dbname = "integer";
		private $conn = null;
		private $name;


		function __construct() {

			try {
				$this->conn = new PDO("mysql:host=$this->servername;dbname=$this->dbname", $this->username, $this->password);
			}
			catch(PDOException $e) {
				echo $e->getMessage();
			}
		}

		function __destruct() {
			$this->conn = null;
		}

		public function showList(){
			$display = $this->conn->prepare("SELECT * FROM drugs");
			$display->execute();
		}

		
	}




?>