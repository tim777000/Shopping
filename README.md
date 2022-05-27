# Shopping
> 余庭光 Tim Yu
## 使用方式
* 先確認您有安裝Docker，並啟動Docker
* 把此Repository Pull下來，cd進第一層
```bash=
cd Shopping
```
* Dockerfile已寫好，執行build
```bash=
docker build -t shopping .
```
* build結束後直接以下run指令便可運行sever
```bash=
docker run -d --name shopping -p 8888:8888 shopping
```
* server運作於localhost:8888 ，在瀏覽器輸入localhost:8888/swagger可進入類似postman可輕鬆執行API的介面
### Product API
Product共有兩個API，分別為View以及Add，View可觀看目前所有商品，Add可添加新商品或增加既有商品的存貨量，或修改既有商品價格
#### 用法
* localhost:8888/Product/View
* localhost:8888/Product/Add，加上Post Data
```json=
{
    "Name":"XXX",
    "Price": X,
    "Inventory": X
}
```

### Cart API
Cart共有三個API，此API有user區別，三API分別為View、Add以及Checkout，View可觀看user的Cart，Add可添加商品進user的Cart，其中Post Data內可以選擇商品數量，Checkout會將user的Cart內所有物品清空並轉換成訂單(以下{Name}請自行替換程使用者名稱)
:::warning
注意，重複Checkout會覆蓋舊訂單
:::
#### 用法
* localhost:8888/{Name}/Cart/View
* localhost:8888/{Name}/Cart/Add，加上Post Data
```json=
{
    "Name":"XXX",
    "Price": X,
    "Amount": X
}
```
* localhost:8888/{Name}/Cart/Checkout

### Order API
Order僅有一支API，此API有user區別，API為View，可觀看user最近的訂單(以下{Name}請自行替換程使用者名稱)
#### 用法
* localhost:8888/{Name}/Order/View