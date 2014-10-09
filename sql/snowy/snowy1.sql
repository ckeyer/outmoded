-- For mysql
-- create databases,tables&users

-- set character
set character_set_client=utf8;
set character_set_connection=utf8;
set character_set_database=utf8;
set character_set_results=utf8;
set character_set_server=utf8;

-- create databases
CREATE database db_snowy CHARACTER SET utf8 collate utf8_general_ci;

--
use db_snowy;
---- tables
-- 用户表:
DROP TABLE IF EXISTS 'tb_user';
CREATE TABLE tb_user
(
 id NUMBER(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
 username VARCHAR2(64) NOT NULL ,
 password CHAR(64) NOT NULL AUTO_INCREMENT,
 salt CHAR(8) NOT NULL, 
 email varchar2(64) NOT NULL ,
 nickname text ,
 sex  int  CHECK(sex IN(0 ,1)) ,
 birth datetime ,
 headPic longblob ,
 description text ,
 care varchar(256),
 created datetime DEFAULT NULL,
 updated datetime DEFAULT NULL,

 role int(11) DEFAULT NULL,
 balance int(11) DEFAULT NULL,
 reputation int(11) DEFAULT(100) NULL,
 topic_count NUMBER DEFAULT(0) NOT NULL ,
 project_count NUMBER DEFAULT(0) NOT NULL ,
 reply_count NUMBER DEFAULT(0) NOT NULL ,
 friend_count NUMBER DEFAULT(0) NOT NULL ,
 group_count NUMBER DEFAULT(0) NOT NULL ,
 weibo text,
 github text,
 douban text
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS 'tb_group';
CREATE TABLE tb_group
(
 id NUMBER(11) NOT NULL AUTO_INCREMENT,
 groupname VARCHAR2(64) NOT NULL ,
 create_time datetime NOT NULL ,
 last_time datetime ,
 master_id NUMBER(11) NOT NULL ,
 description VARCHAR(256) ,
 admin_count  NUMBER DEFAULT(0) NOT NULL ,
 user_count  NUMBER DEFAULT(0) NOT NULL ,
 project_count NUMBER DEFAULT(0) NOT NULL ,
 topic_count NUMBER DEFAULT(0) NOT NULL ,
 reply_count NUMBER DEFAULT(0) NOT NULL ,
 keyword text,
 PRIMARY KEY(id) 
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS 'tb_topic';
CREATE TABLE tb_topic (
  id int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  title text,
  author_id int(11) NOT NULL,
  content text,
  status int(11) DEFAULT NULL,
  created datetime DEFAULT NULL,
  updated datetime DEFAULT NULL,
  node_id int(11) DEFAULT NULL,
  reply_count int(11) DEFAULT NULL,
  scan_count int(11) DEFAULT NULL,
  collect_count int(11) DEFAULT NULL, -- 被收藏数
  last_replied_time datetime DEFAULT NULL,
  up_vote int(11) DEFAULT NULL,
  down_vote int(11) DEFAULT NULL,
  last_touched datetime DEFAULT NULL,
  PRIMARY KEY (id)
) 
ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS 'tb_reply';
CREATE TABLE tb_reply (
  id int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  topic_id int(11) DEFAULT NULL,
  reply_id int(11) DEFAULT NULL,
  author_id int(11) DEFAULT NULL,
  content text,
  created datetime DEFAULT NULL,
  updated datetime DEFAULT NULL,
  up_vote int(11) DEFAULT NULL,
  down_vote int(11) DEFAULT NULL,
  last_touched datetime DEFAULT NULL,
  PRIMARY KEY (id)
) 
ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS 'tb_notification';
CREATE TABLE tb_notification (
  id int(11) NOT NULL AUTO_INCREMENT,
  author_id int(11) NOT NULL,
  content text,
  status int(11) DEFAULT NULL,
  involved_type int(11) DEFAULT NULL,
  involved_user_id int(11) DEFAULT NULL,
  involved_topic_id int(11) DEFAULT NULL,
  involved_reply_id int(11) DEFAULT NULL,
  trigger_user_id int(11) DEFAULT NULL,
  occurrence_time datetime DEFAULT NULL,
  PRIMARY KEY (id)
) 
ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS 'tb_node';
CREATE TABLE tb_node (
  id int(11) NOT NULL AUTO_INCREMENT,
  name text,
  description text,
  parent_node int(11),
  topic_count int(11) DEFAULT 0,
  group_count int(11) DEFAULT 0,
  user_count int(11) DEFAULT 0,
  PRIMARY KEY (id)
) 
ENGINE=InnoDB AUTO_INCREMENT=10000 DEFAULT CHARSET=utf8;

CREATE TABLE tb_project
(
 id NUMBER(6) NOT NULL AUTO_INCREMENT,
 projectname VARCHAR2(64) NOT NULL ,
 version CHAR(12) ,
 createTime datetime NOT NULL ,
 lastTime datetime ,
 master_id NUMBER(9) NOT NULL ,
 parentProj_id NUMBER(6) ,
 description VARCHAR(256) ,
 logo_pic longblob ,
 admin_count NUMBER DEFAULT(0) NOT NULL ,
 author_count NUMBER DEFAULT(0) NOT NULL ,
 childProj_count NUMBER DEFAULT(0) NOT NULL ,
 topic_count NUMBER DEFAULT(0) NOT NULL ,
 reply_count NUMBER DEFAULT(0) NOT NULL ,
 keyword text,
 PRIMARY KEY(id) 
)
ENGINE=InnoDB  AUTO_INCREMENT = 10000 DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS 'tb_user_topic_favorite';
CREATE TABLE tb_user_topic_favorite (
  id int(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL ,
  topic_id int(11) NOT NULL ,
  PRIMARY KEY (id)
) ENGINE=InnoDB ;

DROP TABLE IF EXISTS 'tb_user_topic_scan';
CREATE TABLE tb_user_topic_scan (
  id int(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL ,
  topic_id int(11) NOT NULL ,
  PRIMARY KEY (id)
) ENGINE=InnoDB ;

DROP TABLE IF EXISTS 'tb_user_topic_collect';
CREATE TABLE tb_user_topic_collect (
  id int(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL ,
  topic_id int(11) NOT NULL ,
  PRIMARY KEY (id)
) ENGINE=InnoDB ;

DROP TABLE IF EXISTS 'tb_group_user';
CREATE TABLE tb_group_user (
  id int(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL ,
  group_id int(11) NOT NULL ,
  role int(11) DEFAULT NULL , --是否是管理员等
  PRIMARY KEY (id)
) ENGINE=InnoDB ;

DROP TABLE IF EXISTS 'tb_topic_reply';
CREATE TABLE tb_topic_reply (
  id int(11) NOT NULL AUTO_INCREMENT,
  topic_id int(11) NOT NULL ,
  reply_id int(11) NOT NULL ,
  PRIMARY KEY (id)
) ENGINE=InnoDB ;

DROP TABLE IF EXISTS 'tb_project_topic';
CREATE TABLE tb_topic_reply (
  id int(11) NOT NULL AUTO_INCREMENT,
  project_id int(11) NOT NULL ,
  topic_id int(11) NOT NULL ,
  PRIMARY KEY (id)
) ENGINE=InnoDB ;
