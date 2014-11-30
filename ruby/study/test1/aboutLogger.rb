#!/usr/local/bin/ruby

require "logger"

# logger = Logger.new(STDOUT)  #输出到控制台
# logger = Logger.new("log.txt")  #输出到文件，文件名log.txt
# logger = Logger.new(STDERR) #输出到屏幕
#  file = File.open('foo.log', File::WRONLY | File::APPEND)
#   # To create new (and to remove old) logfile, add File::CREAT like;
#   # file = open('foo.log', File::WRONLY | File::APPEND | File::CREAT)
# logger = Logger.new(file) 

logger = Logger.new(STDERR)
logger.level = Logger::DEBUG

# 修改时间格式：
logger.datetime_format = "%Y-%m-%d %H:%M:%S"

# 修改日志格式：
logger.formatter = proc { |severity, datetime, progname, msg|
"#{severity[0]} #{datetime}: #{msg}\n"
}

logger.fatal("some desption")
logger.error("some desption")
logger.warn("some desption")
logger.info("some desption")
logger.debug("some desption")

logger.add(Logger::FATAL) { 'Fatal error!' }
