package main

import (
	"crypto/md5"
	"crypto/sha256"
	"fmt"
	"hash"
	"io"
)

func main() {
	f := md5.New()

	s := MD5("fuck", f)
	fmt.Println(s)

	s = SHA256("fuck")
	fmt.Println(s)
}

func MD5(s string, f hash.Hash) (md5s string) {
	io.WriteString(f, s)
	md5s = fmt.Sprintf("%x", f.Sum(nil))
	return
}

func SHA256(s string) (md5s string) {

	h := sha256.New()
	io.WriteString(h, s)
	md5s = fmt.Sprintf("%x", h.Sum(nil))
	return
}
