﻿using System;
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
        //Microsoft.DirectX.Direct3D.Device  device;
        #region
        //保存3D文件
        private Mesh mesh = null;
        //设备
        private Device device = null;
        //材质
        private Material[] meshMaterials;
        //纹理
        private Texture[] meshTextures;
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

        public ShowConnect()
        {
            InitializeComponent();
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
            //创建设备
            //因为我显示在panel1中，所以device中的第三个变量是panel的名字
            device = new Device(0, DeviceType.Hardware, this,
                CreateFlags.SoftwareVertexProcessing, presentParams);
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
                mesh = Mesh.FromFile(file, MeshFlags.Managed, device, out mtrl);
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
            device.RenderState.Ambient = Color.Black;
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.AntiqueWhite;
            device.Lights[0].Direction = new Vector3(1, 0, 0);
            device.Lights[0].Update();
            device.Lights[0].Enabled = true;

        }
        //绘制mesh的材质和纹理
        private void DrawMesh(float yaw, float pitch, float roll, float x, float y, float z)
        {
            // angle += 0.01f;
            device.Transform.World = Matrix.RotationYawPitchRoll(yaw, pitch, roll) * Matrix.Translation(x, y, z);
            for (int i = 0; i < meshMaterials.Length; ++i)
            {
                //设置材质
                device.Material = meshMaterials[i];
                //设置纹理
                device.SetTexture(0, meshTextures[i]);
                //绘制
                mesh.DrawSubset(i);
            }
        }

        private void Render()
        {
            if (device == null)
                return;
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.SkyBlue, 1.0f, 1);

            //device.Clear(ClearFlags.Target, System.Drawing.Color.Black, 1.0f, 0);
            SetupCamera();
            device.BeginScene();

            Material boxMaterial = new Material();
            boxMaterial.Ambient = Color.Pink;
            boxMaterial.Diffuse = Color.White;
            device.Material = boxMaterial;
            device.Transform.World = Matrix.Translation(0, 50, 0);
            device.Transform.World = Matrix.Identity;
            //DrawMesh(angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle / (float)Math.PI / 4.0f, 0.0f, 0.0f, 0.0f);
            for (int i = 0; i < meshMaterials.Length; ++i)
            {
                //设置材质
                device.Material = meshMaterials[i];
                //设置纹理
                device.SetTexture(0, meshTextures[i]);
                //绘制
                mesh.DrawSubset(i);
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

        private void show1_Click(object sender, EventArgs e)
        {
            InitializeGraphics();

            while (true) //设置一个循环用于实时更新渲染状态
            {
                Render();
                Application.DoEvents(); //处理键盘鼠标等输入事件
            }

        }


    }
}