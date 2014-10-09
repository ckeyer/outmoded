/**
 * Created with IntelliJ IDEA.
 * User: liaojie
 * Date: 12-9-8
 * Time: 下午3:53
 * To change this template use File | Settings | File Templates.
 */
package main

import (
	"crypto/md5"
	"crypto/sha1"
	"crypto/sha256"
	"crypto/sha512"
	"flag" //命令行选项解析器
	"fmt"
	"hash"
	"io"
	"os"
)

var style = flag.String("s", "sha256", "采用的哈西函数:sha1,sha256")
var filename = flag.String("f", "", "需要计算散列值的文件名")

func main() {
	flag.Parse()
	var hs hash.Hash

	switch *style {
	case "md5":
		hs = md5.New()
	case "sha1":
		hs = sha1.New()
	case "sha512":
		hs = sha512.New()
	default:
		hs = sha256.New()
	}

	if len(*filename) == 0 {
		filein, err := os.Open(flag.Args()[len(flag.Args())-1])
		if err != nil {
			return
		} else {
			io.Copy(hs, filein)
		}
	} else {
		filein, err := os.Open(*filename)
		if err != nil {
			return
		} else {
			io.Copy(hs, filein)
		}
	}
	hashString := hs.Sum(nil)
	fmt.Printf("%x\n", hashString)
}
