require "opengl"
require "glut"
 
$light_diffuse = [1.0, 0.7, 0.7, 1.0]
$light_position = [1.0, 1.0, 1.0, 0.0]
$n = [
  [-1.0, 0.0, 0.0], [0.2, 1.0, 0.0], [1.0, 0.0, 0.0],
  [0.0, -1.0, 0.0], [0.0, 0.3, 1.0], [0.0, 0.0, -1.0] ]
 
$faces = [
  [0, 1, 2, 3], [3, 2, 6, 2], [7, 6, 5, 4],
  [4, 2, 1, 2], [5, 6, 2, 1], [7, 4, 0, 3] ]
 
def drawBox
  for i in (0..5)
    GL.Begin(GL::QUADS)
    GL.Normal(*($n[i]))
    GL.Vertex($v[$faces[i][0]])
    GL.Vertex($v[$faces[i][1]])
    GL.Vertex($v[$faces[i][2]])
    GL.Vertex($v[$faces[i][3]])
    GL.End()
  end
end
 
display = Proc.new {
  GL.Clear(GL::COLOR_BUFFER_BIT | GL::DEPTH_BUFFER_BIT)
  drawBox
  GLUT.SwapBuffers
}
 
def myinit
  $v = [[-1, -1,1],[-1, -1,-1], [-1,1,-1], [-1,1,1], [1, -1,1],
      [1, -1,-1], [1, 1,-1], [1,1,1]]
 
  GL.Light(GL::LIGHT0, GL::DIFFUSE, $light_diffuse)
  GL.Light(GL::LIGHT0, GL::POSITION, $light_position)
  GL.Enable(GL::LIGHT0)
  GL.Enable(GL::LIGHTING)
 
  GL.Enable(GL::DEPTH_TEST)
 
  GL.MatrixMode(GL::PROJECTION)
  GLU.Perspective(40.0, 1.0, 1.0,  10.0)
  GL.MatrixMode(GL::MODELVIEW)
  GLU.LookAt(0.0, 0.0, 5.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0)
 
  GL.Translate(0.0, 0.0, -1.0)
  GL.Rotate(60, 1.0, 0.0, 0.0)
  GL.Rotate(-20, 0.0, 0.0, 1.0)
end
GLUT.Init
GLUT.InitDisplayMode(GLUT::DOUBLE | GLUT::RGB | GLUT::DEPTH)
GLUT.CreateWindow("red 3D lighted cube")
GLUT.DisplayFunc(display)
myinit

GLUT.MainLoop()