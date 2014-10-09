package main

import (
	"bytes"
	"errors"
	"fmt"
)

func main() {
	s := "hello world,download you with my self, my world"
	comps := "world"
	tobs := StrToBytes("dear")
	bs := StrToBytes(s)
	compb := StrToBytes(comps)

	fmt.Printf("%s\n", bs)
	// bss, n := ReplaceBytes(bs, compb, tobs)
	bss, n := ReplaceLastBytes(bs, compb, tobs)
	fmt.Printf("%s\n", bss)
	fmt.Println(n)
}

func RmInt(sr []int, n int) (ds []int, changeCount int) {
	changeCount = 0
	ds, err := RmFirstInt(sr, n)
	for err == nil {
		changeCount++
		ds, err = RmFirstInt(ds, n)
	}
	return
}

func RmFirstInt(sr []int, n int) (ds []int, err error) {
	err = nil
	ds = sr
	for i := 0; i < len(sr); i++ {
		if sr[i] == n {
			ds = append(sr[:i], sr[i+1:]...)
			return
		}
		if i == len(sr)-1 {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func RmLastInt(sr []int, n int) (ds []int, err error) {
	err = nil
	ds = sr
	for i := len(sr) - 1; i >= 0; i-- {
		if sr[i] == n {
			ds = append(sr[:i], sr[i+1:]...)
			return
		}
		if i == 0 {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func StrToBytes(s string) (bs []byte) {
	for i := 0; i < len(s); i++ {
		bs = append(bs, s[i])
	}
	return
}

func BytesToStr(bs []byte) (s string) {
	s = fmt.Sprintf("%s", bs)
	return
}

func RmByte(sr []byte, n byte) (ds []byte, changeCount int) {
	changeCount = 0
	ds, err := RmFirstByte(sr, n)
	for err == nil {
		changeCount++
		ds, err = RmFirstByte(ds, n)
	}
	return
}

func RmFirstByte(sr []byte, n byte) (ds []byte, err error) {
	err = nil
	ds = sr
	for i := 0; i < len(sr); i++ {
		if sr[i] == n {
			ds = append(sr[:i], sr[i+1:]...)
			return
		}
		if i == len(sr)-1 {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func RmLastByte(sr []byte, n byte) (ds []byte, err error) {
	err = nil
	ds = sr
	for i := len(sr) - 1; i >= 0; i-- {
		if sr[i] == n {
			ds = append(sr[:i], sr[i+1:]...)
			return
		}
		if i == 0 {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func RmBytes(sr []byte, n []byte) (ds []byte, changeCount int) {
	changeCount = 0
	ds, err := RmFirstBytes(sr, n)
	for err == nil {
		changeCount++
		ds, err = RmFirstBytes(ds, n)
	}
	return
}

func RmFirstBytes(sr []byte, comp []byte) (ds []byte, err error) {
	err = nil
	length := len(comp)
	ds = sr
	for i := 0; i < len(sr); i++ {
		if bytes.Equal(sr[i:i+length], comp) {
			ds = append(sr[:i], sr[i+length:]...)
			return
		}
		if i == len(sr)-length {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func RmLastBytes(sr []byte, comp []byte) (ds []byte, err error) {
	err = nil
	length := len(comp)
	ds = sr
	for i := len(sr) - 1; i >= 0; i-- {
		if bytes.Equal(sr[i:i+length], comp) {
			ds = append(sr[:i], sr[i+length:]...)
			return
		}
		if i == length-1 {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func ReplaceBytes(sr []byte, fromb []byte, tob []byte) (ds []byte, changeCount int) {
	changeCount = 0
	ds, err := ReplaceFirstBytes(sr, fromb, tob)
	for err == nil {
		changeCount++
		ds, err = ReplaceFirstBytes(ds, fromb, tob)
	}
	return
}

func ReplaceFirstBytes(sr []byte, fromb []byte, tob []byte) (ds []byte, err error) {
	err = nil
	length := len(fromb)
	ds = make([]byte, 0)
	for i := 0; i < len(sr); i++ {
		ds = append(ds, sr[i])
	}
	for i := 0; i < len(sr); i++ {
		if bytes.Equal(sr[i:i+length], fromb) {
			tmp := append(ds[:i], tob[:]...)
			ds = append(tmp, sr[i+length:]...)
			return
		}
		if i == len(sr)-length {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}

func ReplaceLastBytes(sr []byte, fromb []byte, tob []byte) (ds []byte, err error) {
	err = nil
	length := len(fromb)
	ds = make([]byte, 0)
	for i := 0; i < len(sr); i++ {
		ds = append(ds, sr[i])
	}
	for i := len(sr) - length; i >= 0; i-- {
		if bytes.Equal(sr[i:i+length], fromb) {
			tmp := append(ds[:i], tob[:]...)
			ds = append(tmp, sr[i+length:]...)
			return
		}
		if i == len(sr)-length {
			err = errors.New("No one in this slice")
			return
		}
	}
	return
}
