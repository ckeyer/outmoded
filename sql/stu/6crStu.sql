use db_stu;
create table tb_students
(
	chr_stu_num char(11) CHARACTER SET utf8 COLLATE utf8_bin not null,
	chr_stu_name varchar(12) CHARACTER SET utf8 COLLATE utf8_bin,
	int_class_id int ,
	chr_stu_sex char(2)  CHARACTER SET utf8 COLLATE utf8_bin,
	dat_stu_enrol date ,
	dat_stu_birth date ,
	chr_per_id char(18) CHARACTER SET utf8 COLLATE utf8_bin,
	chr_stu_address varchar(128) CHARACTER SET utf8 COLLATE utf8_bin,
	int_stu_source int(6),
	int_nation_id int
)                                                                                                                                                                                                                             
