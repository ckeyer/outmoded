

CREATE DATABASE dbo DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;

SET character_set_client = utf8; 
SET character_set_connection = utf8; 
SET character_set_database = utf8; 
SET character_set_results = utf8;/*这里要注意很有用*/ 
SET character_set_server = utf8; 
 
SET collation_connection = utf8_bin; 
SET collation_database = utf8_bin; 
SET collation_server = utf8_bin; 


create user 'test'@'localhost' identified by 'manager';

grant all on dbo to test@localhost;


