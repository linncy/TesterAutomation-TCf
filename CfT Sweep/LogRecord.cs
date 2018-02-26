using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LogRecord
{
    class LogClass
    {
        /**//// <summary>
            /// 写入日志文件
            /// </summary>
            /// <param name="input"></param>
        FileInfo finfo;

        public FileInfo CreateFile( string filename)
        {
            /**/
            ///指定日志文件的目录
            System.IO.Directory.CreateDirectory("D:\\LRC\\data\\");
            string fname = "D:\\LRC\\data\\"+ filename + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".csv";
            /**/
            ///定义文件信息对象

            finfo = new FileInfo(fname);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }
            return finfo;
        }

        public void WriteLogFile(string input)
        {

            ///创建只写文件流

            using (FileStream fs = finfo.OpenWrite())
            {
                /**/
                ///根据上面创建的文件流创建写数据流
                StreamWriter w = new StreamWriter(fs);

                /**/
                ///设置写数据流的起始位置为文件流的末尾
                w.BaseStream.Seek(0, SeekOrigin.End);

                ///写入日志内容并换行
                w.Write(input + "\r\n");

                /**/
                ///清空缓冲区内容，并把缓冲区内容写入基础流
                w.Flush();

                /**/
                ///关闭写数据流
                w.Close();
            }

        }
    }
}