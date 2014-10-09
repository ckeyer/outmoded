package main

import (
	"fmt"
)

func main() {
	msg := `
<cjstudio>
  <From>
    <IPAddress></IPAddress>
    <Port></Port>
    <UserID></UserID>
    <Name></Name>
  </From>
  <To>
    <IPAddress></IPAddress>
    <Port></Port>
    <UserID></UserID>
    <Name></Name>
  </To>
  <Data>
  </Data>
  <Hash>
  </Hash>
</cjstudio>`
	fmt.Println(msg)
}
