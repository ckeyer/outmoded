#!/usr/local/bin/ruby
require 'mysql'
begin
    db = Mysql.init
    db.options(Mysql::SET_CHARSET_NAME, 'utf8')
    db = Mysql.real_connect("127.0.0.1", "wcj", "wangcj", "db_test", 3306)
    db.query("SET NAMES utf8")
    # db.query("drop table if exists tb_test")
    # db.query("create table tb_test (id int,text LONGTEXT) ENGINE=MyISAM DEFAULT CHARSET=utf8")
    # db.query("insert into tb_test (id, text) values (1,'first line'),(2,'second line')")
    # printf "%d rows were inserted\n",db.affected_rows
    rslt = db.query("select * from tb_addresss")
    while row = rslt.fetch_row do
        puts "#{row[0]}:#{row[1]}"
    end
rescue Mysql::Error => e
    puts "Error code: #{e.errno}"
    puts "Error message: #{e.error}"
    puts "Error SQLSTATE: #{e.sqlstate}" if e.respond_to?("sqlstate")
ensure
    db.close if db
end
