
use db_snowy;

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







