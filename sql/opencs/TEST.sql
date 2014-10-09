
------- 表约束的查看
select table_name ,constraint_name from user_constraints
where constraint_name NOT LIKE('SYS%')
and constraint_name NOT LIKE('BIN%')
;

select count(constraint_name) from user_constraints
where constraint_name NOT LIKE('SYS%')
and constraint_name NOT LIKE('BIN%')
;


------ 查看序列
select SEQUENCE_NAME from user_sequences ;

------ 查看触发器
select trigger_name from user_triggers ;


--参数文件和网络连接文件
SQL> show parameter spfile;

--控制文件
SQL> select * from v$controlfile;

--数据文件
SQL> select FILE_NAME from dba_data_files;

--日志文件
SQL> select * from v$logfile;


select constraint_name, constraint_type,search_condition, r_constraint_name   
from user_constraints where table_name = upper('&table_name'); 




