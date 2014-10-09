


insert into tb_user(username , password ,email) 
values('wcj' ,'123','cjstudio@yeah.net');
insert into tb_user(username , password ,email) 
values('cjstudio' ,'123456','cj_studio@yeah.net');
insert into tb_user(username , password ,email) 
values('a1' ,'123456','a1@yeah.net');
insert into tb_user(username , password ,email) 
values('a2' ,'123456','a2@yeah.net');
insert into tb_user(username , password ,email) 
values('a3' ,'123456','a3@yeah.net');
insert into tb_user(username , password ,email) 
values('a4' ,'123456','a4@yeah.net');
insert into tb_user(username , password ,email) 
values('a5' ,'123456','a5@yeah.net');
insert into tb_user(username , password ,email) 
values('a6' ,'123456','a6@yeah.net');
insert into tb_user(username , password ,email) 
values('a7' ,'123456','a7@yeah.net');
insert into tb_user(username , password ,email) 
values('a8' ,'123456','a8@yeah.net');

create index in_useremail on tb_user (email) TABLESPACE SPUSER_INDEX;
create index in_userID on tb_user (userID) TABLESPACE SPUSER_INDEX;
create index in_jourID on tb_journal (journalID) TABLESPACE SPUSER_INDEX;
create index in_replID on tb_reply (replyID) TABLESPACE SPUSER_INDEX;
create index in_grouID on tb_group (groupID) TABLESPACE SPUSER_INDEX;
create index in_projID on tb_project (projectID) TABLESPACE SPUSER_INDEX;


