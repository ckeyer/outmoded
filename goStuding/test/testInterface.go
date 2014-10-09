package main

import (
	"fmt"
)

type USB interface {
	Connect()
	GetName() string
}

type Disk struct {
	Id   string
	Name string
	Size float64
}

func (d Disk) GetName() string {
	return d.Name
}

func (d Disk) Connect() {
	fmt.Println("Connect successful: ", d.GetName())
}

func main() {
	var disk USB = Disk{Id: "54631564", Name: "mydisk1", Size: 640}

	switch v := disk.(type) {
	case Disk:
		fmt.Println("1#", v, "#")
	case USB:
		fmt.Println("2#", v, "#")
	default:
		fmt.Println("error")
	}
}
