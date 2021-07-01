```js
// static props , it will save data during build, it will serve generated html pages.

import React from "react";
import Link from "next/link";


export async function getStaticProps() {
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
