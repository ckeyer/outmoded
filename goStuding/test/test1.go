package main

import (
	"fmt"
)

const (
	myCon1 = iota + iota
	myCon2
	myCon3 = 5
)

func main() {
	世界 := "中国"
	fmt.Println("hello,world 你好,世界")
	fmt.Println(myCon1, myCon2, myCon3, 世界)
}
