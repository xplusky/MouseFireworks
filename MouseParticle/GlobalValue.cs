using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseParticle
{
    public class GlobalValue
    {
        /// <summary>
        /// 全局随机函数，从时间取得种子，保证每次都不一样
        /// </summary>
        public static Random random = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// 起始透明度
        /// </summary>
        public const double OPACITY = 1;
        /// <summary>
        /// 每次添加多少个粒子
        /// </summary>
        public const double FIREWORK_NUM = 2;
        /// <summary>
        /// 重力
        /// </summary>
        public const double GRAVITY = 0.1;
        /// <summary>
        /// 偏移X
        /// </summary>
        public const double X_VELOCITY = 5;
        /// <summary>
        /// 偏移Y
        /// </summary>
        public const double Y_VELOCITY = 5;
        /// <summary>
        /// 最小的半径
        /// </summary>
        public const int SIZE_MIN = 1;
        /// <summary>
        /// 最大的半径
        /// </summary>
        public const int SIZE_MAX = 10;
        /// <summary>
        /// 透明度衰减值
        /// </summary>
        public const double OpacityInc = -0.02;
    }
}
