package main

import (
	"fmt"
)

func main() {
	m1 := map[string]string{"hello": "world", "ok": "haha"}
	m1["en"] = "a"
	fmt.Println(m1["hello"])
	fmt.Println(m1["en"])

	//两个map交换键值
	fmt.Println("Test 2:")
	m2 := map[int]string{1: "hello", 2: "world", 4: "download", 5: "you"}
	m3 := make(map[string]int)
	for k, v := range m2 {
		m3[v] = k
	}
	fmt.Println("m2:", m2, "\nm3:", m3)
}
