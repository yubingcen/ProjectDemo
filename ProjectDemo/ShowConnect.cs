using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace ProjectDemo
{
    public partial class ShowConnect : Form
    {
        Microsoft.DirectX.Direct3D.Device  device;
        //Device device2;

        private Mesh meshObj;//定义茶壶模型对象
        private Material material;//定义材质变量

        private float angleY = 0.01f;//定义绕Y轴旋转变量
        private Vector3 CamPostion = new Vector3(0, 30, -30);//定义摄像机位置
        private Vector3 CamTarget = new Vector3(0, 0, 0);//定义摄像机目标位置

        private int mouseLastX, mouseLastY;//记录鼠标按下时的坐标位置
        private bool isRotateByMouse = false;//记录是否由鼠标控制旋转
        private bool isMoveByMouse = false;//记录是否由鼠标控制移动

        public ShowConnect()
        {
            InitializeComponent();
            InitializeDirect3D();
        }


        public bool InitializeDirect3D()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true; //指定以Windows窗体形式显示 
                presentParams.SwapEffect = SwapEffect.Discard; //当前屏幕绘制后,它将自动从内存中删除
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                presentParams.EnableAutoDepthStencil = true;
                //表示Direct3D是否为应用程序自动管理深度缓存，这个成员为TRUE的话，表示需要自动管理深度缓存，这时候就需要对下一个成员AutoDepthStencilFormat进行相关像素格式的设置。
                //AutoDepthStencilFormat：如果我们把EnableAutoDepthStencil成员设为TRUE的话，在这里就需要指定AutoDepthStencilFormat的深度缓冲的像素格式。具体格式可以在结构体D3DFORMAT中进行选取。
                presentParams.PresentationInterval = PresentInterval.Immediate;
                device = new Microsoft.DirectX.Direct3D.Device(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams); //实例化device对象 
                //device2 = new Device(0, DeviceType.Hardware, this.panel2, CreateFlags.SoftwareVertexProcessing, presentParams); //实例化device对象 

                meshObj = Mesh.Torus(device, 15, 30, 100, 40);//定义圆环模型对象
                //定义材质
                material = new Material();
                material.Ambient = Color.FromArgb(0, 10, 10, 10);//设置环境光
                material.Diffuse = Color.LightGreen;//设置漫反射
                material.Emissive = Color.FromArgb(0, 0, 0, 0);//设置自发光
                material.Specular = Color.DarkRed;//设置镜面反射光
                material.SpecularSharpness = 15.0f;//反射高光清晰度

                return true;
            }
            catch (DirectXException e)
            {
                MessageBox.Show(e.ToString(), "Error"); //处理异常 
                return false;
            }
        }

        // 渲染
        public void Render()
        {
            if (device == null)
            {
                return;
            }

            SetUpCamera();
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.DarkSlateBlue, 1.0f, 0);  //清除windows界面为深蓝色

           // device.Clear(ClearFlags.Target, Color.DarkSlateBlue, 1.0f, 0);  //清除windows界面为深蓝色
            device.BeginScene();
            //在此添加渲染图形代码

            device.RenderState.Lighting = true;
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = System.Drawing.Color.White;
            device.Lights[0].Direction = new Vector3(-1.0f, 1.0f, 1.0f);
            device.Lights[0].Enabled = true; //打开灯光
            device.Lights[1].Type = LightType.Directional;
            device.Lights[1].Diffuse = System.Drawing.Color.LightGray;
            device.Lights[1].Direction = new Vector3(1f, -1.0f, 1.0f);
            device.Lights[1].Enabled = true; //打开灯光            
            device.RenderState.Ambient = Color.SlateGray;
            device.RenderState.CullMode = Cull.None;

            //设置绘图设备当前的材质属性
            device.Material = material;
            meshObj.DrawSubset(0);//绘制模型

            device.EndScene();
            device.Present();

        }

        private void SetUpCamera()//摄像机
        {
            Matrix viewMatrix = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 0.3f, 500f);
            device.Transform.View = viewMatrix;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Vector4 tempV4;
            Matrix currentView = device.Transform.View;//当前摄像机的视图矩阵
            switch (e.KeyCode)
            {
                case Keys.Left:
                    CamPostion.Subtract(CamTarget);
                    tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                            Quaternion.RotationAxis(new Vector3(currentView.M12, currentView.M22, currentView.M32), -angleY)));
                    CamPostion.X = tempV4.X + CamTarget.X;
                    CamPostion.Y = tempV4.Y + CamTarget.Y;
                    CamPostion.Z = tempV4.Z + CamTarget.Z;
                    break;
                case Keys.Right:
                    CamPostion.Subtract(CamTarget);
                    tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                            Quaternion.RotationAxis(new Vector3(currentView.M12, currentView.M22, currentView.M32), angleY)));
                    CamPostion.X = tempV4.X + CamTarget.X;
                    CamPostion.Y = tempV4.Y + CamTarget.Y;
                    CamPostion.Z = tempV4.Z + CamTarget.Z;
                    break;
                case Keys.Up:
                    CamPostion.Subtract(CamTarget);
                    tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                       Quaternion.RotationAxis(new Vector3(device.Transform.View.M11
                       , device.Transform.View.M21, device.Transform.View.M31), -angleY)));
                    CamPostion.X = tempV4.X + CamTarget.X;
                    CamPostion.Y = tempV4.Y + CamTarget.Y;
                    CamPostion.Z = tempV4.Z + CamTarget.Z;
                    break;
                case Keys.Down:
                    CamPostion.Subtract(CamTarget);
                    tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                       Quaternion.RotationAxis(new Vector3(device.Transform.View.M11
                       , device.Transform.View.M21, device.Transform.View.M31), angleY)));
                    CamPostion.X = tempV4.X + CamTarget.X;
                    CamPostion.Y = tempV4.Y + CamTarget.Y;
                    CamPostion.Z = tempV4.Z + CamTarget.Z;
                    break;
                case Keys.Add:
                    CamPostion.Subtract(CamTarget);
                    CamPostion.Scale(0.95f);
                    CamPostion.Add(CamTarget);
                    break;
                case Keys.Subtract:
                    CamPostion.Subtract(CamTarget);
                    CamPostion.Scale(1.05f);
                    CamPostion.Add(CamTarget);
                    break;
            }
            Matrix viewMatrix = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
            device.Transform.View = viewMatrix;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLastX = e.X;
                mouseLastY = e.Y;
                isRotateByMouse = true;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mouseLastX = e.X;
                mouseLastY = e.Y;
                isMoveByMouse = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isRotateByMouse = false;
            isMoveByMouse = false;

            base.OnMouseDown(e);
            MessageBox.Show("鼠标按下的位置在：X=" + e.X.ToString() + ",Y=" + e.Y.ToString());
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isRotateByMouse)
            {
                Matrix currentView = device.Transform.View;//当前摄像机的视图矩阵
                float tempAngleY = 2 * (float)(e.X - mouseLastX) / this.Width;
                CamPostion.Subtract(CamTarget);//前者减去后面，转换向量

                Vector4 tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                    Quaternion.RotationAxis(new Vector3(currentView.M12, currentView.M22, currentView.M32), tempAngleY)));//该方法通过矩阵源矩阵转换传入向量的向量数组。
                CamPostion.X = tempV4.X;
                CamPostion.Y = tempV4.Y;
                CamPostion.Z = tempV4.Z;

                float tempAngleX = 4 * (float)(e.Y - mouseLastY) / this.Height;
                tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                    Quaternion.RotationAxis(new Vector3(currentView.M11, currentView.M21, currentView.M31), tempAngleX)));
                CamPostion.X = tempV4.X + CamTarget.X;
                CamPostion.Y = tempV4.Y + CamTarget.Y;
                CamPostion.Z = tempV4.Z + CamTarget.Z;
                Matrix viewMatrix = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
                device.Transform.View = viewMatrix;

                mouseLastX = e.X;
                mouseLastY = e.Y;
            }
            else if (isMoveByMouse)
            {
                Matrix currentView = device.Transform.View;//当前摄像机的视图矩阵
                float moveFactor = 0.01f;
                CamTarget.X += -moveFactor * ((e.X - mouseLastX) * currentView.M11 - (e.Y - mouseLastY) * currentView.M12);
                CamTarget.Y += -moveFactor * ((e.X - mouseLastX) * currentView.M21 - (e.Y - mouseLastY) * currentView.M22);
                CamTarget.Z += -moveFactor * ((e.X - mouseLastX) * currentView.M31 - (e.Y - mouseLastY) * currentView.M32);

                CamPostion.X += -moveFactor * ((e.X - mouseLastX) * currentView.M11 - (e.Y - mouseLastY) * currentView.M12);
                CamPostion.Y += -moveFactor * ((e.X - mouseLastX) * currentView.M21 - (e.Y - mouseLastY) * currentView.M22);
                CamPostion.Z += -moveFactor * ((e.X - mouseLastX) * currentView.M31 - (e.Y - mouseLastY) * currentView.M32);

                Matrix viewMatrix = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
                device.Transform.View = viewMatrix;
                mouseLastX = e.X;
                mouseLastY = e.Y;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float scaleFactor = -(float)e.Delta / 2000 + 1f;
            CamPostion.Subtract(CamTarget);
            CamPostion.Scale(scaleFactor);
            CamPostion.Add(CamTarget);
            Matrix viewMatrix = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
            device.Transform.View = viewMatrix;
        }

        private void show1_Click(object sender, EventArgs e)
        {
            while (true) //设置一个循环用于实时更新渲染状态
            {
                Render(); //保持device渲染，直到程序结束
                //CameraTransform.SetUpCamera();//建立摄像机
                Application.DoEvents(); //处理键盘鼠标等输入事件
            }
        }

        private void show2_Click(object sender, EventArgs e)
        {
            while (true) //设置一个循环用于实时更新渲染状态
            {
                Render(); //保持device渲染，直到程序结束
                //CameraTransform.SetUpCamera();//建立摄像机
                Application.DoEvents(); //处理键盘鼠标等输入事件
            }
        }
    }
}
