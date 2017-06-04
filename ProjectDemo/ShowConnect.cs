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
        //开始渲染
        Boolean running = false;
        Boolean auto = false;
        //Microsoft.DirectX.Direct3D.Device  device;
        #region
        //保存3D文件
        private Mesh[] mesh = null;
        //设备
        private Device device = null;
        //材质
        private Material[] meshMaterials;
        //纹理
        private Texture[] meshTextures;
        //定义模型网格的位置
        private Matrix[] meshPosition;

        //获取当前程序的Debug路径
        string path = System.Windows.Forms.Application.StartupPath;
        //角度
        //private float angle = 0.0f;
        #endregion
        private Vector3 CamPostion = new Vector3(0, 30, -100);//定义摄像机位置
        private Vector3 CamTarget = new Vector3(0, 0, 0);//定义摄像机目标位置

        private int mouseLastX, mouseLastY;//记录鼠标按下时的坐标位置
        private bool isRotateByMouse = false;//记录是否由鼠标控制旋转
        private bool isMoveByMouse = false;//记录是否由鼠标控制移动

        float angle = 0.01f;
        public ShowConnect()
        {
            InitializeComponent();
            InitializeGraphics();
        }

        //初始化图形设备
        public void InitializeGraphics()
        {
            //设置变量
            PresentParameters presentParams = new PresentParameters();
            //设置在窗口模式下运行
            presentParams.Windowed = true;
            //设置交换效果为Discard
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;
            presentParams.PresentationInterval = PresentInterval.Immediate;

            //创建设备
            //因为我显示在panel1中，所以device中的第三个变量是panel的名字
            device = new Device(0, DeviceType.Hardware, this,
                CreateFlags.SoftwareVertexProcessing, presentParams);

            //创建两个模型
            mesh = new Mesh[2];
            //定义位置
            meshPosition = new Matrix[2];
            meshPosition[0] = Matrix.Translation(-20f, 0f, 0f);
            meshPosition[1] = Matrix.Translation(20f, 0f, 0f);

            //我的3D文件在Debug中的Model文件中，因此temp获取了3D模型的地址
            string temp = path;
            temp = temp + "\\Model\\Model.X";
            //这个函数用于载入3D模型并且保存在mesh中
            LoadMesh(temp);

            SetupCamera();

        }

        private void LoadMesh(string file)
        {
            ExtendedMaterial[] mtrl = null;
            //载入
            try
            {
                for (int num = 0; num < mesh.Length; num++)
                {
                    mesh[num] = Mesh.FromFile(file, MeshFlags.Managed, device, out mtrl);
                    //有材质的话，则载入
                    if ((mtrl != null) && (mtrl.Length > 0))
                    {
                        //这两个就是前面定义的全局变量，保存材质和纹理
                        meshMaterials = new Material[mtrl.Length];
                        meshTextures = new Texture[mtrl.Length];

                        for (int i = 0; i < mtrl.Length; ++i)
                        {
                            /*当前的temp是Debug下的Model文件，
                            *Model文件中有保存纹理和材质的文件
                             */
                            string temp = path + "\\Model\\";
                            meshMaterials[i] = mtrl[i].Material3D;
                            if ((mtrl[i].TextureFilename != null)
                                && mtrl[i].TextureFilename != string.Empty)
                            {
                                meshTextures[i] = TextureLoader.FromFile(device, temp + mtrl[i].TextureFilename);
                            }
                        }
                    }
                }
            }
            catch (Direct3DXException ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        //设置摄像头
        private void SetupCamera()
        {
            //(float)Math.PI/12设置对象大小
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 12, this.Width / this.Height, 0.80f, 10000.0f);
            device.Transform.View = Matrix.LookAtLH(CamPostion, CamTarget, new Vector3(0, 1, 0));
        }
        //绘制mesh的材质和纹理
        private void DrawMesh(float yaw, float pitch, float roll, float x, float y, float z)
        {
            angle += 0.01f;
            device.Transform.World = Matrix.RotationYawPitchRoll(yaw, pitch, roll) * Matrix.Translation(x, y, z);
            for (int i = 0; i < meshMaterials.Length; ++i)
            {
                //设置材质
                device.Material = meshMaterials[i];
                //设置纹理
                device.SetTexture(0, meshTextures[i]);
                //绘制
                mesh[0].DrawSubset(i);
            }
        }

        private void Render()
        {
            if (device == null)
                return;
            SetupCamera();
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.DarkSlateBlue, 1.0f, 1);
            //device.Clear(ClearFlags.Target, System.Drawing.Color.Black, 1.0f, 0);
            device.BeginScene();

            // 灯光
            device.RenderState.Lighting = true;
            //设置三种不同类型的灯光
            LightsCollection lightsCollection = device.Lights;
            //第一个灯光为点光源
            lightsCollection[0].Type = LightType.Point;
            lightsCollection[0].Diffuse = System.Drawing.Color.Green;
            lightsCollection[0].Position = new Vector3(-10.0f, 10.0f, 10.0f);
            lightsCollection[0].Range = 50.0f;
            lightsCollection[0].Attenuation1 = 0.1f;
            lightsCollection[0].Enabled = true; //打开灯光
            //第二个灯光为平行光
            lightsCollection[1].Type = LightType.Directional;
            lightsCollection[1].Diffuse = System.Drawing.Color.Green;
            lightsCollection[1].Direction = new Vector3(0.0f, -1.0f, 1.0f);
            lightsCollection[1].Enabled = true; //打开灯光
            //第三个灯光为聚光灯
            lightsCollection[2].Type = LightType.Spot;
            lightsCollection[2].Diffuse = System.Drawing.Color.Green;
            lightsCollection[2].Position = new Vector3(5.0f, 5.0f, 5.0f);
            lightsCollection[2].Direction = new Vector3(0.0f, -1.0f, 1.0f);
            lightsCollection[2].Range = 50.0f;
            lightsCollection[2].Attenuation1 = 0.1f;
            lightsCollection[2].OuterConeAngle = 45f;
            lightsCollection[2].Enabled = true; //打开灯光

            device.RenderState.CullMode = Cull.None;

            Material boxMaterial = new Material();
            //boxMaterial.Ambient = Color.Pink;
            //boxMaterial.Diffuse = Color.White;
            boxMaterial.Ambient = Color.FromArgb(0, 10, 10, 10);//设置环境光 
            boxMaterial.Diffuse = Color.LightGreen;//设置漫反射 
            boxMaterial.Emissive = Color.FromArgb(0, 0, 0, 0);//设置自发光 
            boxMaterial.Specular = Color.DarkRed;//设置镜面反射光
            boxMaterial.SpecularSharpness = 15.0f;//反射高光清晰度 

            device.Material = boxMaterial;
            device.Transform.World = Matrix.Translation(0, 50, 0);
            device.Transform.World = Matrix.Identity;

            // 可以自动旋转
            if (auto)
            {
                DrawMesh(angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle / (float)Math.PI / 4.0f, 0.0f, 0.0f, 0.0f);
            }
            else {
                for (int num = 0; num < mesh.Length; num++)
                {
                    for (int i = 0; i < meshMaterials.Length; ++i)
                    {
                        //设置材质
                        device.Material = meshMaterials[i];
                        //设置纹理
                        device.SetTexture(0, meshTextures[i]);
                    }
                    //绘制
                    //设置当前世界矩阵
                    device.Transform.World = meshPosition[num];
                    mesh[num].DrawSubset(0);
                }
            }

           

            //mesh.DrawSubset(0);
            device.EndScene();
            device.Present();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
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

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isRotateByMouse = false;
            isMoveByMouse = false;
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

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isRotateByMouse)
            {
                Matrix currentView = device.Transform.View;//当前摄像机的视图矩阵
                float tempAngleY = 2 * (float)(e.X - mouseLastX) / this.Width;
                CamPostion.Subtract(CamTarget);

                Vector4 tempV4 = Vector3.Transform(CamPostion, Matrix.RotationQuaternion(
                    Quaternion.RotationAxis(new Vector3(currentView.M12, currentView.M22, currentView.M32), tempAngleY)));
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

        // 重置视角
        private void ResetPerspective_Click(object sender, EventArgs e)
        {
            CamPostion = new Vector3(0, 30, -100);//定义摄像机位置
            SetupCamera();
        }

        //退出
        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确定退出程序吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                running = false;
                Application.ExitThread();
            }
            else
            {
                // e.Cancel = true;
            }
        }

        private void CloseRender(object sender, FormClosingEventArgs e)
        {

            DialogResult result;
            result = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                running = false;
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void autoModel_Click(object sender, EventArgs e)
        {
            auto = true;
        }

        // 开始渲染
        private void LoadingModel_Click(object sender, EventArgs e)
        {
            running = true;
            auto = false;
            while (running) //设置一个循环用于实时更新渲染状态
            {
                Render();
                Application.DoEvents(); //处理键盘鼠标等输入事件
            }
        }

    }
}