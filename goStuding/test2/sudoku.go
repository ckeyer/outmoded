package main

import (
	"fmt"
)

type node []int

var sudokuMay [9][9]node

var Sudoku = [9][9]int{
	{0, 0, 0, 0, 0, 0, 8, 0, 0},
	{0, 8, 2, 4, 0, 0, 0, 0, 0},
	{1, 9, 0, 0, 6, 3, 0, 0, 0},
	{0, 5, 0, 0, 8, 0, 7, 0, 0},
	{6, 7, 8, 2, 0, 9, 1, 4, 3},
	{0, 0, 3, 0, 4, 0, 0, 8, 0},
	{0, 0, 0, 6, 2, 0, 0, 9, 4},
	{0, 0, 0, 0, 0, 5, 6, 1, 0},
	{0, 0, 0, 6, 0, 0, 0, 0, 0}}

func main() {
	n := inited(Sudoku)
	SudokuSure, _ := sure(sudokuMay)
	for n > 0 {
		n = Subinit(SudokuSure)
		// Output(sudokuMay)
		// fmt.Println(n)
		SudokuSure, _ = sure(sudokuMay)
	}
	Output(sudokuMay)
	fmt.Println(isEnable(sudokuMay))
	// test()
}

func isEnable(tn [9][9]node) bool {
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			if len(tn[i][j]) == 0 {
				return false
			}
		}
	}
	return true
}

func sure(may [9][9]node) (sure [9][9]int, n int) {
	n = 0
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			if len(may[i][j]) == 1 {
				sure[i][j] = may[i][j][0]
				n++
			} else {
				sure[i][j] = 0
			}
		}
	}
	return
}

func test() {
	i, j := 1, 3
	fmt.Println(Sudoku[i][j])
	for k := ((i / 3) * 3); k < ((i/3)*3)+3; k++ {
		for l := ((j / 3) * 3); l < ((j/3)*3)+3; l++ {
			fmt.Print(Sudoku[k][l])
		}
		fmt.Println(" ")
	}
}

func inited(Sud [9][9]int) (changeCount int) {
	tmp := 0
	changeCount = 0
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			if Sud[i][j] != 0 {
				sudokuMay[i][j] = append(sudokuMay[i][j], Sud[i][j])
			} else {
				for k := 0; k < 9; k++ {
					sudokuMay[i][j] = append(sudokuMay[i][j], k+1)
				}
				sudokuMay[i][j], tmp = excludeMay(i, j, sudokuMay[i][j], Sud)
				changeCount += tmp
			}
		}
	}
	return
}

func Subinit(Sud [9][9]int) (changeCount int) {
	tmp := 0
	changeCount = 0
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			if Sud[i][j] != 0 {
				sudokuMay[i][j][0] = Sud[i][j]
			} else {
				sudokuMay[i][j], tmp = excludeMay(i, j, sudokuMay[i][j], Sud)
				changeCount += tmp
			}
		}
	}
	return
}

func excludeMay(ti, tj int, t node, S [9][9]int) (rmay node, changeCount int) {
	changeCount = 0
	var tmpChangeCount int
	for i := 0; i < 9; i++ {
		if S[i][tj] != 0 {
			t, tmpChangeCount = exclude(t, S[i][tj])
			changeCount += tmpChangeCount
		}
		if S[ti][i] != 0 {
			t, tmpChangeCount = exclude(t, S[ti][i])
			changeCount += tmpChangeCount
		}
	}
	for k := ((ti / 3) * 3); k < ((ti/3)*3)+3; k++ {
		for l := ((tj / 3) * 3); l < ((tj/3)*3)+3; l++ {
			if S[k][l] != 0 {
				t, tmpChangeCount = exclude(t, S[k][l])
				changeCount += tmpChangeCount
			}
		}

	}
	rmay = t
	return
}

func excludeFirstOne(smay node, n int) (rmay node, changeCount int) {
	changeCount = 0
	rmay = smay
	for i := 0; i < len(smay); i++ {
		if smay[i] == n {
			changeCount++
			rmay = append(smay[:i], smay[i+1:]...)
			return
		}
		if i == len(smay)-1 {
			return
		}
	}
	return
}

func exclude(smay node, n int) (tmp node, changeCount int) {
	var nc int
	changeCount = 0
	tmp, nc = excludeFirstOne(smay, n)
	for nc > 0 {
		tmp, nc = excludeFirstOne(tmp, n)
		changeCount++
	}
	return
}

func Output(sudoku [9][9]node) {
	for i := 0; i < 9; i++ {
		for j := 0; j < 9; j++ {
			fmt.Print(sudokuMay[i][j])
		}
		fmt.Println("")
	}
}
