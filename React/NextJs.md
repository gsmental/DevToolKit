```js
//To gettings static data from array/url to state. It will fetch all data during build.  Add all data into js files and no need to fetch again.

export async function getStaticProps() {
  const res = await fetch("https://jsonplaceholder.typicode.com/posts");
  const posts = await res.json();

  return {
    props: {
      posts,
    },
  };
}
```

