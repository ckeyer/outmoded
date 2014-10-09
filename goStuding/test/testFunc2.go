package main

import (
	"fmt"
)

func main() {
	var fs = [4]func(){}
	for i := 0; i < 4; i++ {
		defer fmt.Println("defer1: i= ", i)
		defer func() {
			fmt.Println("defer2: i= ", i) // 闭包思想
		}()
		fs[i] = func() {
			fmt.Println("defer3: i= ", i) // 闭包思想
		}
	}
	for _, v := range fs {
		v()
	}

	fmt.Println("Test 2:")
	// FuncA()
	// FuncB()
	// FuncC()
}

func FuncA() {
	fmt.Println("funA is runing")
}

func FuncB() {
	defer func() {
		if err := recover(); err != nil {
			fmt.Println("Panic ...")
			FuncC()
		}
	}()
	panic("PanicB is runing")
}

func FuncC() {
	fmt.Println("funC is runing")
}
