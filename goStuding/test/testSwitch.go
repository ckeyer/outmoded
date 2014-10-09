package main

import (
	"fmt"
)

func main() {
	a := 4
	switch a {
	case 1:
		fmt.Println("a=1")
	case 2:
		fmt.Println("a=2")
	case 3, 4, 5:
		fmt.Println("a=3,4,5")
		fallthrough
	default:
		fmt.Println("a=other")
	}

	switch {
	case a == 4:
		fmt.Println("a=4")
		fallthrough
	case a >= 4:
		fmt.Println("a>=4")
	default:
		fmt.Println("a<4")
	}
}
