<template>
  <div>
    <el-container style="height: 100%; border: 1px solid #eee">
      <el-aside width="200px" style="background-color: rgb(238, 241, 246)">
        <el-menu
          style="height: 100%"
          :collapse="isCollapse"
          :default-active="activeIndex"
          :unique-opened="true"
          router
          ref="elMenu"
          @select="menuSelect"
        >
          <mymenu :data="menuArr" />
        </el-menu>
      </el-aside>

      <el-container>
        <el-header style="text-align: right; font-size: 12px">
          <el-dropdown>
            <i class="el-icon-setting" style="margin-right: 15px"></i>
            <el-dropdown-menu slot="dropdown">
              <el-dropdown-item>查看</el-dropdown-item>
              <el-dropdown-item>新增</el-dropdown-item>
              <el-dropdown-item>删除</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
          <span>王小虎</span>
        </el-header>

        <el-main>
          <router-view />
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<style>
.el-header {
  background-color: #b3c0d1;
  color: #333;
  line-height: 60px;
}

.el-aside {
  color: #333;
}
</style>

<script>
import mymenu from "../views/MenuList.vue";
export default {
  components: {
    mymenu,
  },
  data() {
    return {
      isCollapse: false,
      activeIndex: this.$route.path,
      tableData: [],
      // 然后再通过权限管理页面，去添加或修改这个树结构，这样的话，前端就会呈现出来了
      menuArr: [],
    };
  },
  mounted() {
    console.log(this.$route);
    this.getmenu();
  },
  methods: {
    menuSelect(index) {
      this.activeIndex = index;
    },
    getmenu() {
      this.$axios.get("Menu/GetMenuAll").then((d) => {
        this.menuArr = d.data;
      });
    },
  },
};
</script>