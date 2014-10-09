package main

import (
	"fmt"
	"time"
)

var maxC chan int
var over = make(chan int)

func main() {
	maxC = make(chan int, 2)
	for i := 0; i < 10; i++ {
		go query(i)
		// time.Sleep(time.Second * 1)
	}
	<-over
	close(maxC)
	fmt.Println("Over...")
}

func query(n int) {
	maxC <- 1
	fmt.Println("Func " + fmt.Sprint(n) + " start")
	if n == 9 {
		over <- 1
	}
	time.Sleep(time.Second * 2)
	<-maxC
}
