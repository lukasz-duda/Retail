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
    const li = document.createElement("li");
    li.textContent = `OrderPlaced received, OrderId = ${orderId}`;
    document.getElementById("messages").appendChild(li);
});

connection.start();