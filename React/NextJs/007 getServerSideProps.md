```js
// first of all it will fetch data from api then send to props, it internet is not working, it will give error 500,but on client side no api url will be visible.

import React from "react";
import Link from "next/link";
export async function getServerSideProps() {
  const res = await fetch("https://jsonplaceholder.typicode.com/posts");
  const posts = await res.json();

  return {
    props: {
      posts
    },
  };
}
const posts=({posts})=>{

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
