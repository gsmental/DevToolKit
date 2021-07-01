```js
// simple ul list with josb object
import React from "react";
import Link from "next/link";

const posts=()=>{
    const posts = [
      {
        userId: 1,
        id: 1,
        title:
          "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
        body:
          "quia et suscipit\nsuscipit recusandae consequuntur expedita et ",
      },
      {
        userId: 1,
        id: 2,
        title: "qui est esse",
        body:
          "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat",
      },
      {
        userId: 1,
        id: 3,
        title: "ea molestias quasi exercitationem repellat qui ipsa sit aut",
        body:
          "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel acc",
      }
]
    return(<div>
       <ul>
      {posts.map((post) => {
        return (
          <li key={post.id}>
            <h3>
              <Link href="/posts/[id]" as={"/posts/" + post.id}>
                <a>{post.title}</a>
              </Link>
            </h3>
            <p>{post.body}</p>
          </li>
        );
      })}
    </ul>
    </div>)
}

export default posts;

```
