package main

import (
	"fmt"
)

func main() {
	var str string
	// n, err := fmt.Sscanf("%s", str)
	// if n > 0 && err == nil {
	// 	fmt.Println(str)
	// } else {
	// 	fmt.Println("Fuck")
	// }
	fmt.Scanln(&str)
	fmt.Println(str)
}
