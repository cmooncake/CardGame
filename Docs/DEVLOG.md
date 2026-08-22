## 2026-08-23

### 今日唯一目标

完成 Lobby 与 DeckEditor 的双向场景切换。

### 今日完成

- [x] 创建并配置 Lobby 场景
- [x] 实现 BootApp 自动进入 Lobby
- [x] 创建可复用的 GameFlowButton
- [x] 创建导航按钮 Prefab
- [x] 实现 Lobby → BuildDeck
- [x] 实现 BuildDeck → Lobby
- [x] 完成运行验证
- [x] 检查 Unity Console
- [x] 提交并推送 Git

### 运行验证

验证链路：

BootApp → Lobby → BuildDeck → Lobby

验证结果：

- CurrentState 与活动场景一致
- AppRoot 实例数量始终为 1
- AppRoot 位于 DontDestroyOnLoad
- 两个按钮的 OnClick 绑定有效
- 没有新增场景框架错误

### 遇到的问题

- CardStore.cs:26 仍有 NullReferenceException
- 对 git status --short 的两列含义掌握不牢
- Prefab 最初误命名为 GameFlowButtom

### 今日复盘

- UI 只负责表达导航意图
- GameFlowManager 负责验证和更新流程状态
- SceneLoader 负责调用 Unity 场景加载 API
- SerializeField private 同时满足 Inspector 配置和代码封装
- Prefab 保存共性，实例 Override 保存场景差异
- Git 状态第一列表示暂存区，第二列表示工作区

### 下一步

分析并拆分 CardStore 的卡牌数据加载、玩家数据与商店职责。