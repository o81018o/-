用于易查分平台的批量查询
引用了@statianzo的Fleck https://github.com/statianzo/Fleck 
通过油猴脚本和本地应用程序搭配，二者通过websocket通讯
第一查询条件应位于驱动器D的1.txt，第二查询条件应为与驱动器D的2.txt，输出位于驱动器D的3.txt，内容以“#”分割
将查询页和结果页的@match改为相应地址
查询完成后务必点击停止按钮再关闭，否则可能造成数据缺失
如果遇到查询失败，刷新页面会查询下一条
