const connection = new signalR.HubConnectionBuilder()
    .withUrl("/retailhub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();


async function placeOrder() {
    const orderId = self.crypto.randomUUID();
    await connection.invoke("PlaceOrder", orderId);
}

connection.on("OrderPlaced", (orderId) => {
    const item = document.createElement("li");
    item.classList.add('list-group-item')
    item.textContent = `OrderPlaced received, OrderId = ${orderId}`;
    document.getElementById("messages").appendChild(item);
});

connection.start();