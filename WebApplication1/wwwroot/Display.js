var parent = document.getElementById("parent");
const xhttpr = new XMLHttpRequest();
xhttpr.open('GET', 'https://localhost:7196/api/images', true);
xhttpr.send();
xhttpr.onload = () => Handel(xhttpr);
function Handel(x) {
    if (x.status === 200) {
        const response = JSON.parse(x.response);
        console.log(response);
        console.log(typeof response);
        console.log(typeof x.response)
        response.forEach(obj => {
            console.log(obj)
            var img = document.createElement("img");
            img.src = obj;
            parent.appendChild(img);
        });
    }
}
/*

const xhttpr = new XMLHttpRequest();
xhttpr.open('GET', 'https://localhost:7196/api/images', true);
xhttpr.send();
xhttpr.onload = () => {
    if (xhttpr.status === 200) {
        const response = JSON.parse(xhttpr.response);
        console.log(response);
        response.forEach(obj => {
            Object.entries(obj).forEach(([value]) => {
                console.log(`${value}`);
                var img = document.createElement("img");
                img.src = value;
                parent.appendChild(img);
            });
            console.log('-------------------');
        });
    }
}
*/