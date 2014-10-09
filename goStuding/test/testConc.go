package main

import (
	"fmt"
	"runtime"
	"sync"
)

const (
	n = 4
)

func main() {
	runtime.GOMAXPROCS(runtime.NumCPU())
	wg := sync.WaitGroup{}
	wg.Add(n)
	//var s [n]int
	for i := 0; i < n; i++ {
		go fun5(&wg, i)
	}
	// c := make(chan int, n)
	// for i := 0; i < n; i++ {
	// 	go fun4(c, i)
	// }
	wg.Wait()
	// ss := 0
	// for i := 0; i < n; i++ {
	// 	ss += s[i]
	// }
	// fmt.Println(ss)
	//fmt.Println(runtime.NumCPU())
}

func fun5(wg *sync.WaitGroup, index int) {

	for i := index; i < 200000000; i += n {
		//s[i] += index
	}
	fmt.Println("hhhhh", index)
	wg.Done()
}

// func fun4(c chan int, index int) {
// 	a := 0
// 	for i := index; i < 200000000; i += n {
// 		a += i
// 	}
// 	c <- a
// }

// func main() {
// 	runtime.GOMAXPROCS(runtime.NumCPU())
// 	var c1, c2 = make(chan int), make(chan int)
// 	go fun1(c1)
// 	go fun2(c2)
// 	s1 := <-c1
// 	s2 := <-c2
// 	fmt.Println(s1 + s2)
// 	// 	c := make(chan int)
// 	// 	go fun3(c)
// 	// 	fmt.Println(<-c)
// }

// func fun1(c chan int) {
// 	var a int = 0
// 	for i := 0; i < 100000000; i++ {
// 		a += i
// 	}
// 	c <- a
// }

// func fun2(c chan int) {
// 	var a int = 0
// 	for i := 100000001; i < 200000000; i++ {
// 		a += i
// 	}
// 	c <- a
// }

// func fun3(c chan int) {
// 	var a int = 0
// 	for i := 0; i < 200000000; i++ {
// 		a += i
// 	}
// 	c <- a
// }
