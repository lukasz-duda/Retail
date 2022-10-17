const connection = new signalR.HubConnectionBuilder()
    .withUrl("/retailhub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();


async function placeOrder() {
    const message = new Date().toLocaleTimeString();
    await connection.invoke("PlaceOrder", `PlaceOrder ${message}`);
}

connection.on("OrderPlaced", (message) => {
    const li = document.createElement("li");
    li.textContent = `${message}`;
    document.getElementById("messages").appendChild(li);
});

connection.start();