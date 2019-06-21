# Leonie Flowchart



```mermaid
graph TD
A((Start))-->B
B(Leonie Actions)-->C
C(Wait)-->D
C-->|Timeout|B
D(User Input)-->E
E(Dialogflow)-->B
```

## Software side

- Leonie Actions: Latest Dialogflow Response
  - Display
  - Speech
- Activate the user input components
  - Which will raise a `user-input` event
- Get the `user-input` event
  - If it's a timeout, go back to displaying the main menu (camera)
  - Otherwise, send it to Dialogflow and [restart the cycle again](https://youtu.be/qUiRhJgD76E?t=65)
