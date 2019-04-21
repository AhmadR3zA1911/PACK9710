using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Copy_File
{
    class FileAction
    {
        public string FilePath { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// 
        public FileAction()
        {

        }
        /// <summary>
        /// Set FilePath Variable
        /// </summary>
        /// <param name="_path"></param>
        public FileAction(string _path)
        {
            this.FilePath = _path;
        }

        public string FindFilePath(string _path)
        {
            if (FilePath!=null)
            {
                return FilePath;
            }

            else

            {
                return FilePath;
            }
        }
    }

}
