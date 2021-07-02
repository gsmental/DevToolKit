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
              <Link href="/post/[id]" as={"/post/" + post.id}>
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


```tsx
///[id].tsx --create at root/pages/post

import React, { Context } from "react";
import { useRouter } from "next/router";

export default function Post( props:any ) {
    const router = useRouter();
  
    // If the page is not yet generated, this will be displayed
    // initially until getStaticProps() finishes running
    if (router.isFallback) {
      return <div>Loading Page Data...</div>;
    }
  
    return (
      <div>
        <h2>{props.postData.title}</h2>
        <p>{props.postData.body}</p>
      </div>
    );
  }

//   export async function getStaticPaths() {
//     const paths = ["/posts/1", "/posts/2"];
//     return { paths, fallback: true };
//   }


  export async function getServerSideProps(pageContext:any) {
pageContext.query.id
    console.log(pageContext.query.id);
 
   // const { id } = query || params;
  
    const res = await fetch("https://jsonplaceholder.typicode.com/posts/" + pageContext.query.id);
    const postData = await res.json();
  
    return {
      props: {
        postData,
      },
    };
  }
//post/[id].tsx

```



