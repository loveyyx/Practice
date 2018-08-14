 # **Python 爬虫简单实战**
 __________________

 ### 运用scrapy框架爬取B站视屏每日播放排行榜
 
[目标页面链接][https://www.bilibili.com/ranking?spm_id_from=333.334.banner_link.6]

爬取内容：视频名字title，链接url，热度grade，作者up

_____________

### 环境依赖
* python 3.7
* install scarpy

______

### 准备步骤
* [打开页面链接](https://www.bilibili.com/ranking?spm_id_from=333.334.banner_link.6)
* 对页面检查，分析所需要内容
______________
### 代码编写
* 首先使用scrapy 在桌面创建一个名为demo的新文件
</br> `scrapy startproject demo`
*  打开demo文件中的items.py
</br> 输入代码
``` python
import scrapy
class demoItem(scrapy.Item):
    title=scrapy.Field() #题目
    link=scrapy.Field()  #链接
    grade=scrapy.Field() #分数
    up=scrapy.Field()    #作者
```
* 打开demo中的spider文件，新建一个python文件
</br> 输入代码
``` python
    import scrapy
from demo.items import demoItem

class DemoSpider(scrapy.Spider):
    name="demo"
    allowed_domains = ['demo.org']
    start_urls=[
        "https://www.bilibili.com/ranking?spm_id_from=333.334.banner_link.6"
        ]

    def parse(self,response):
        
```
______________________
#### 接下来完成 parse 函数的编写
* 首先需要找到title,url,grade,up对应的Xpath
<br>  分析页面结构，所需内容的路径
<br>输入CMD命令
` scrapy shell "https://www.bilibili.com/ranking?spm_id_from=333.334.banner_link.6"`
<br>使用`scrapy.selector.Selector(response).xpath('')`输入xpath路径进行尝试操作，最后找到Title的路径为`scrapy.selector.Selector(response).xpath('//ul/li/div/div[@class="info"]/a/text()').extract() `
<br>使用同样方法找到up,grade,url对应的Xpath路径
* 将对应路径写入parse部分
``` python
sel = scrapy.selector.Selector(response) 
        sites=sel.xpath('//ul/li/div/div[@class="info"]')
        items=[]
        
        for site in sites:
            item=demoItem()
            item['title'] =site.xpath('a/text()').extract()
            item['link'] =site.xpath('a/@href').extract()
            item['grade']=site.xpath('div[@class="pts"]/div/text()').extract()
            item['up']=site.xpath('div[@class="detail"]/a/span/text()').extract()
            items.append(item)
        return items
``` 
_______________
* 添加解码设置：使用utf-8方式进行解码
<br>在demo文件夹中setting.py加入代码
<br>  `FEED_EXPORT_ENCODING = 'utf-8'`
________
* ### 运行爬虫
在CMD界面输入`scrapy crawl demo -o items.json` 
<br>完成后，在demo文件夹中生成了items的json文件，打开后
![items.json](https://github.com/lw-2018/lw/blob/master/pic/4.png)
<br>与原网页排行榜内容一致
<br>![原网页排行榜](https://github.com/lw-2018/lw/blob/master/pic/5.png)
<br> 爬取成功

