# PlatformJumping
 
### 操作

- 左右移动(A/D/左/右）
- 跳（空格键）
  - 可以与左右移动同时按，实现左跳右跳
  - 必须与地面接触
- 爬墙（Q）
  - 碰到墙之后按Q抓住梯子
  - 爬墙时（W/S/上/下），需要同时按Q
- 冲（E）
  - 目前方向上左冲或右冲

### 敌人

- 碰到后生命-1
- 跳到敌人头上可以杀死敌人
- 种类
  - 负鼠
    - 左右移动
  - 青蛙
    - 未进入范围时不动
    - 在player进入范围后左右跳跃

### 其它伤害

- 碰到后生命-1
- 种类
  - 铁锤
  - 火焰
    - 碰到后小跳一下

### 奖励机制

- 钻石
  - 拿到后跟随，在屋子处被收集，score++
  - 在跟随过程中，受到伤害钻石消失
- 樱桃
  - 拿到后生命立刻加一
  
### 其它机关

- 机关升降台
- 悬挂木盒
- 弹簧

### gameManager

- 死亡，掉落，走出摄像机后自动复活

