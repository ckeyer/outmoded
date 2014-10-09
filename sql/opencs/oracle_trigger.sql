

----创建序列
create sequence sq_userID
increment by 1  
start with 100000000
nomaxvalue
nominvalue
nocache
/

create sequence sq_journalID
increment by 1  
start with 10000000000
nomaxvalue
nominvalue
nocache
/

create sequence sq_groupID
increment by 1  
start with 1000000
nomaxvalue
nominvalue
nocache
/

create sequence sq_projectID
increment by 1  
start with 100000
nomaxvalue
nominvalue
nocache
/

----创建触发器
----逻辑主键的自动填充
create or  replace trigger tr_userID
before insert on tb_user
for each row
begin
select sq_userID.nextval into :new.userID from dual;
end;
/

create or  replace trigger tr_journalID
before insert on tb_journal
for each row
begin
select sq_journalID.nextval into :new.journalID from dual;
end;
/

create or  replace trigger tr_replyID
before insert on tb_reply
for each row
begin
select sq_journalID.nextval into :new.replyID from dual;
end;
/

create or  replace trigger tr_projectID
before insert on tb_project
for each row
begin
select sq_projectID.nextval into :new.projectID from dual;
end;
/

create or  replace trigger tr_groupID
before insert on tb_group
for each row
begin
select sq_groupID.nextval into :new.groupID from dual;
end;
/

----时间戳的自动填充
--日志发表时间
create or replace trigger tr_jour_pubTime
before insert on tb_journal
for each row
begin
	select sysdate into :new.pubTime from dual;
end;
/

--回复时间
create or replace trigger tr_repl_pubTime
before insert on tb_reply
for each row
begin
	select sysdate into :new.pubTime from dual;
end;
/

--项目创建时间
create or replace trigger tr_proj_createTime
before insert on tb_project
for each row
begin
	select sysdate into :new.createTime from dual;
end;
/

--群组创建时间
create or replace trigger tr_grou_createTime
before insert on tb_group
for each row
begin
	select sysdate into :new.createTime from dual;
end;
/

--项目最后动态时间
create or replace trigger tr_proj_lastTime
before update on tb_project
for each row
begin
	select sysdate into :new.lastTime from dual;
end;
/

--群组最后动态时间
create or replace trigger tr_grou_lastTime
before update on tb_project
for each row
begin
	select sysdate into :new.lastTime from dual;
end;
/

--加密用户密码	
create or replace trigger tr_user_passwd
before insert or update of password on tb_User
for each row
--when pg_opencs.passwdType = 1
begin
	select pg_opencs.MD5(:new.password) into :new.password from dual;
end;
/



