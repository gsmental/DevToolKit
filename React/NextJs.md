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


```js
// it will getch server side data, no code will render client side
export async function getServerSideProps({ query }) {
  const { id } = query;
  const res = await fetch("https://jsonplaceholder.typicode.com/posts/" + id);
  const postData = await res.json();
  return {
    props: {
      postData,
    },
  };
}
```

```js
// it will fetch all data during build, in case of addtional/extra parameter, it will give eror 
export async function getStaticPaths() {
  const paths = ["/posts/1", "/posts/2"];
  return { paths, fallback: false };
}
```
```js
// it will fetch all data during build only these paramerster, in case of other parameter it will go to live server.
export async function getStaticPaths() {
  const paths = ["/posts/1", "/posts/2"];
  return { paths, fallback: true };
}
```


