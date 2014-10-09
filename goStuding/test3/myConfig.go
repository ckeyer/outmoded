package main

import (
	"config"
	"fmt"
	"os"
)

func main() {
	conf, err := config.NewConfig(xml, "myconf.conf")
	Checkerr(err)

}

func Checkerr(err error) {
	if err != nil {
		fmt.Println(err)
		os.Exit(0)
	}
}
