with open('e:/GreatRed/GreatRed/MainWindow.xaml', 'r', encoding='utf-8') as f:
    lines = f.readlines()

new_content = ''.join(lines[:568])

new_content += '''                            </StackPanel>
                        </Grid>

                        <!-- COLUMN 1: WORKSPACE PAGES -->
                        <Grid Grid.Column="1" Name="PagesContainerGrid" Margin="10,8">
                            
                             <!-- PAGE 0: SECURITY SCAN -->
                             <Grid Name="PageSecurity" Visibility="Visible" VerticalAlignment="Center">
                                <Border CornerRadius="6" BorderBrush="{StaticResource WidgetBorderBrush}" BorderThickness="1" Padding="0">
                                    <Border.Background>
                                        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                                            <GradientStop Color="#05FF1E56" Offset="0"/>
                                            <GradientStop Color="#0A0909" Offset="1"/>
                                        </LinearGradientBrush>
                                    </Border.Background>
                                    <StackPanel>
                                        <!-- Header -->
                                        <Border Padding="10,8,10,7" BorderThickness="0,0,0,1" BorderBrush="{StaticResource WidgetBorderBrush}">
                                            <Grid>
                                                <TextBlock Text="SECURITY INTEGRITY" FontWeight="ExtraBold" FontSize="8" Foreground="#00FF33" VerticalAlignment="Center">
                                                    <TextBlock.Effect>
                                                        <DropShadowEffect Color="#00FF33" BlurRadius="8" ShadowDepth="0" Opacity="0.3"/>
                                                    </TextBlock.Effect>
                                                </TextBlock>
                                                <TextBlock Text="SYSTEM SHIELD" FontSize="7" FontWeight="Bold" Foreground="{StaticResource TextMutedBrush}" HorizontalAlignment="Right" VerticalAlignment="Center"/>
                                            </Grid>
                                        </Border>

                                        <!-- Content -->
                                        <StackPanel Padding="10">
                                            <!-- Bypass Status -->
                                            <Grid Margin="0,0,0,4">
                                                <TextBlock Text="Kernel Anticheat Bypass" Foreground="{StaticResource TextMutedBrush}" FontFamily="Monospace" FontSize="9"/>
                                                <TextBlock Name="StatusBypass" Text="SECURE" Foreground="#00FF66" FontWeight="Bold" FontFamily="Monospace" FontSize="9" HorizontalAlignment="Right">
                                                    <TextBlock.Effect>
                                                        <DropShadowEffect Color="#00FF66" BlurRadius="6" ShadowDepth="0" Opacity="0.2"/>
                                                    </TextBlock.Effect>
                                                </TextBlock>
                                            </Grid>

                                            <!-- Memory Integrity -->
                                            <Grid Margin="0,0,0,4">
                                                <TextBlock Text="Memory Integrity" Foreground="{StaticResource TextMutedBrush}" FontFamily="Monospace" FontSize="9"/>
                                                <TextBlock Name="StatusMemory" Text="SAFE" Foreground="#00FF66" FontWeight="Bold" FontFamily="Monospace" FontSize="9" HorizontalAlignment="Right">
                                                    <TextBlock.Effect>
                                                        <DropShadowEffect Color="#00FF66" BlurRadius="6" ShadowDepth="0" Opacity="0.2"/>
                                                    </TextBlock.Effect>
                                                </TextBlock>
                                            </Grid>

                                            <!-- Anti Debugging -->
                                            <Grid Margin="0,0,0,4">
                                                <TextBlock Text="Anti-Debugging Shield" Foreground="{StaticResource TextMutedBrush}" FontFamily="Monospace" FontSize="9"/>
                                                <TextBlock Name="StatusDebug" Text="ACTIVE" Foreground="#00FF66" FontWeight="Bold" FontFamily="Monospace" FontSize="9" HorizontalAlignment="Right">
                                                    <TextBlock.Effect>
                                                        <DropShadowEffect Color="#00FF66" BlurRadius="6" ShadowDepth="0" Opacity="0.2"/>
                                                    </TextBlock.Effect>
                                                </TextBlock>
                                            </Grid>

                                            <!-- Progress Bar (Scanning) -->
                                            <Border Name="SecurityProgressContainer" Visibility="Collapsed" Height="4" CornerRadius="2" Background="#141212" BorderBrush="{StaticResource WidgetBorderBrush}" BorderThickness="1" Margin="0,2,0,4">
                                                <Grid>
                                                    <Grid.ColumnDefinitions>
                                                        <ColumnDefinition x:Name="SecurityProgressColDone" Width="0*"/>
                                                        <ColumnDefinition x:Name="SecurityProgressColLeft" Width="100*"/>
                                                    </Grid.ColumnDefinitions>
                                                    <Border Grid.Column="0" Background="#00FF66" CornerRadius="1">
                                                        <Border.Effect>
                                                            <DropShadowEffect Color="#00FF66" BlurRadius="8" ShadowDepth="0" Opacity="1"/>
                                                        </Border.Effect>
                                                    </Border>
                                                </Grid>
                                            </Border>

                                            <!-- Scan Button -->
                                            <Button Name="BtnSecurityScan" Content="SCAN SYSTEM" Style="{StaticResource GreenButtonStyle}" Height="26" FontSize="9" Margin="0,2,0,0" Click="BtnSecurityScan_Click"/>
                                        </StackPanel>
                                    </StackPanel>
                                </Border>
                            </Grid>

                            <!-- PAGE 1: BYPASS CONFIG -->
                             <Grid Name="PageBypass" Visibility="Collapsed" VerticalAlignment="Center">
                                <Border CornerRadius="6" BorderBrush="#1A1A1A" BorderThickness="1" Padding="10,12" Background="#0B0B0B">
                                    <Border.Effect>
                                        <DropShadowEffect Color="#000000" BlurRadius="15" ShadowDepth="4" Opacity="0.6"/>
                                    </Border.Effect>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto"/>
                                            <ColumnDefinition Width="*"/>
                                            <ColumnDefinition Width="Auto"/>
                                        </Grid.ColumnDefinitions>

                                        <!-- Game Icon -->
                                        <Border Grid.Column="0" Width="48" Height="48" CornerRadius="6" BorderBrush="#0FFFFFFF" BorderThickness="1" Margin="0,0,10,0">
                                            <Border.Background>
                                                <ImageBrush ImageSource="free_fire_icon.png" Stretch="UniformToFill"/>
                                            </Border.Background>
                                        </Border>

                                        <!-- Labels -->
                                        <StackPanel Grid.Column="1" VerticalAlignment="Center">
                                            <TextBlock Text="Free Fire" FontWeight="ExtraBlack" FontSize="13" Foreground="#FFFFFF" Margin="0,0,0,2"/>
                                            <TextBlock Name="TxtBypassEmu" Text="Emu: MSI" FontWeight="ExtraBold" FontSize="10" Foreground="{StaticResource TextMutedBrush}" Margin="0,0,0,2"/>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="Engine: " FontWeight="ExtraBold" FontSize="10" Foreground="{StaticResource TextMutedBrush}"/>
                                                <TextBlock Name="TxtBypassState" Text="Offline" FontWeight="ExtraBold" FontSize="10" Foreground="{StaticResource TextMutedBrush}"/>
                                            </StackPanel>
                                        </StackPanel>

                                        <!-- Actions -->
                                        <StackPanel Grid.Column="2" VerticalAlignment="Center" Width="90">
                                            <Button Content="Connect" Height="22" FontSize="10" Margin="0,0,0,4" Click="ConnectBypass_Click">
                                                <Button.Template>
                                                    <ControlTemplate TargetType="Button">
                                                        <Border Name="CBtn" CornerRadius="4" Background="#006F21" BorderBrush="#005619" BorderThickness="1">
                                                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                                        </Border>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger Property="IsMouseOver" Value="True">
                                                                <Setter TargetName="CBtn" Property="Background" Value="#008728"/>
                                                                <Setter TargetName="CBtn" Property="BorderBrush" Value="#006F21"/>
                                                            </Trigger>
                                                            <Trigger Property="IsPressed" Value="True">
                                                                <Setter Property="RenderTransform">
                                                                    <Setter.Value>
                                                                        <ScaleTransform ScaleX="0.96" ScaleY="0.96" CenterX="45" CenterY="11"/>
                                                                    </Setter.Value>
                                                                </Setter>
                                                            </Trigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Button.Template>
                                            </Button>
                                            <Button Content="Disconnect" Height="22" FontSize="10" Click="DisconnectBypass_Click">
                                                <Button.Template>
                                                    <ControlTemplate TargetType="Button">
                                                        <Border Name="DBtn" CornerRadius="4" Background="#8C1D1D" BorderBrush="#701616" BorderThickness="1">
                                                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                                                        </Border>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger Property="IsMouseOver" Value="True">
                                                                <Setter TargetName="DBtn" Property="Background" Value="#A82727"/>
                                                                <Setter TargetName="DBtn" Property="BorderBrush" Value="#8C1D1D"/>
                                                            </Trigger>
                                                            <Trigger Property="IsPressed" Value="True">
                                                                <Setter Property="RenderTransform">
                                                                    <Setter.Value>
                                                                        <ScaleTransform ScaleX="0.96" ScaleY="0.96" CenterX="45" CenterY="11"/>
                                                                    </Setter.Value>
                                                                </Setter>
                                                            </Trigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Button.Template>
                                            </Button>
                                        </StackPanel>
                                    </Grid>
                                </Border>
                            </Grid>

                            <!-- PAGE 2: EMULATOR INSTALLER -->
                             <Grid Name="PageEmu" Visibility="Collapsed" VerticalAlignment="Center">
                                <Border CornerRadius="6" BorderBrush="{StaticResource WidgetBorderBrush}" BorderThickness="1" Padding="0">
                                    <Border.Background>
                                        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                                            <GradientStop Color="#05FF1E56" Offset="0"/>
                                            <GradientStop Color="#0A0909" Offset="1"/>
                                        </LinearGradientBrush>
                                    </Border.Background>
                                    <StackPanel>
                                        <!-- Header -->
                                        <Border Padding="10,8,10,7" BorderThickness="0,0,0,1" BorderBrush="{StaticResource WidgetBorderBrush}">
                                            <Grid>
                                                <TextBlock Text="INSTALLER MENU" FontWeight="ExtraBold" FontSize="8" Foreground="#00FF33" VerticalAlignment="Center">
                                                    <TextBlock.Effect>
                                                        <DropShadowEffect Color="#00FF33" BlurRadius="8" ShadowDepth="0" Opacity="0.3"/>
                                                    </TextBlock.Effect>
                                                </TextBlock>
                                                <TextBlock Text="KERNEL DRIVER" FontSize="7" FontWeight="Bold" Foreground="{StaticResource TextMutedBrush}" HorizontalAlignment="Right" VerticalAlignment="Center"/>
                                            </Grid>
                                        </Border>

                                        <!-- Content -->
                                        <StackPanel Padding="10">
                                            <!-- Dropdown and Request Access -->
                                            <Grid Margin="0,0,0,8">
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="1.15*"/>
                                                    <ColumnDefinition Width="0.85*"/>
                                                </Grid.ColumnDefinitions>

                                                <!-- Emulator Selector Custom Combobox -->
                                                <Grid Grid.Column="0" Margin="0,0,8,0">
                                                    <Border Name="EmuSelectTrigger" Height="24" Background="#070707" BorderBrush="{StaticResource WidgetBorderBrush}" BorderThickness="1" CornerRadius="4" Cursor="Hand" MouseDown="EmuSelectTrigger_MouseDown" Padding="8,0">
                                                        <Grid>
                                                            <TextBlock Name="TxtSelectedEmu" Text="MSI Player" FontSize="9" FontWeight="Bold" Foreground="{StaticResource TextMainBrush}" VerticalAlignment="Center"/>
                                                            <TextBlock Text="▼" FontSize="7" Foreground="{StaticResource TextMutedBrush}" HorizontalAlignment="Right" VerticalAlignment="Center"/>
                                                        </Grid>
                                                    </Border>
                                                    
                                                    <!-- Dropdown items popup container (rendered above elements) -->
                                                    <Popup Name="EmuSelectPopup" PlacementTarget="{Binding ElementName=EmuSelectTrigger}" Placement="Bottom" StaysOpen="False" PopupAnimation="Fade" AllowsTransparency="True">
                                                        <Border Width="170" Background="#0C0B0B" BorderBrush="{StaticResource PanelBorderHoverBrush}" BorderThickness="1" CornerRadius="4" Padding="0">
                                                            <Border.Effect>
                                                                <DropShadowEffect Color="#FF1E56" BlurRadius="10" ShadowDepth="0" Opacity="0.2"/>
                                                            </Border.Effect>
                                                            <StackPanel>
                                                                <!-- Option 1: MSI -->
                                                                <Border Name="EmuOptMsi" Background="{StaticResource CrimsonBrush}" Tag="MSI" Cursor="Hand" MouseDown="EmuOption_MouseDown" Padding="10,5">
                                                                    <TextBlock Text="MSI Player" FontSize="9" FontWeight="Bold" Foreground="#FFFFFF"/>
                                                                </Border>
                                                                <!-- Option 2: Bluestacks -->
                                                                <Border Name="EmuOptBlue" Background="Transparent" Tag="BlueStacks" Cursor="Hand" MouseDown="EmuOption_MouseDown" Padding="10,5">
                                                                    <TextBlock Text="Bluestacks" FontSize="9" FontWeight="Bold" Foreground="{StaticResource TextMainBrush}"/>
                                                                </Border>
                                                            </StackPanel>
                                                        </Border>
                                                    </Popup>
                                                </Grid>

                                                <Button Grid.Column="1" Content="REQUEST ACCESS" Style="{StaticResource ImguiButtonStyle}" Height="24" FontSize="9" Click="RequestAccess_Click"/>
                                            </Grid>

                                            <!-- Install / Uninstall certs -->
                                            <Grid>
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="1*"/>
                                                    <ColumnDefinition Width="1*"/>
                                                </Grid.ColumnDefinitions>
                                                <Button Grid.Column="0" Content="INSTALL CERT" Style="{StaticResource GreenButtonStyle}" Height="26" FontSize="9" Margin="0,0,4,0" Click="InstallCert_Click"/>
                                                <Button Grid.Column="1" Content="UNINSTALL CERT" Style="{StaticResource RedButtonStyle}" Height="26" FontSize="9" Margin="4,0,0,0" Click="UninstallCert_Click"/>
                                            </Grid>
                                        </StackPanel>
                                    </StackPanel>
                                </Border>
                            </Grid>

                            <!-- PAGE 3: PORTAL/WEB -->
                            <Grid Name="PageWeb" Visibility="Collapsed" VerticalAlignment="Center">
                                <Border CornerRadius="6" BorderBrush="{StaticResource WidgetBorderBrush}" BorderThickness="1" Background="#050505" Padding="0">
                                    <StackPanel>
                                        <!-- Header banner with user SVG icon -->
                                        <Border BorderThickness="0,0,0,1" BorderBrush="{StaticResource WidgetBorderBrush}" Padding="8,10,8,7">
                                            <StackPanel Orientation="Horizontal">
                                                <Border Width="24" Height="24" CornerRadius="5" Background="#26FF1E56" BorderBrush="#4DFF1E56" BorderThickness="1">
                                                    <Path Data="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2 M16 7 A 4 4 0 1 1 8 7 A 4 4 0 1 1 16 7" 
                                                          Stroke="{StaticResource CrimsonBrush}" StrokeThickness="2.5" Width="12" Height="12" Stretch="Uniform" VerticalAlignment="Center" HorizontalAlignment="Center"/>
                                                </Border>
                                                <StackPanel VerticalAlignment="Center" Margin="8,0,0,0">
                                                    <TextBlock Text="UID Bypass Portal" FontWeight="ExtraBold" FontSize="10" Foreground="{StaticResource TextHighlightBrush}"/>
                                                    <TextBlock Text="deletehex.com" FontSize="8" Foreground="{StaticResource TextMutedBrush}" Margin="0,1,0,0"/>
                                                </StackPanel>
                                            </StackPanel>
                                        </Border>

                                        <!-- Action link and text -->
                                        <StackPanel Margin="8,10">
                                            <Button Style="{StaticResource AccentButtonStyle}" Height="26" HorizontalAlignment="Stretch" Cursor="Hand" Click="OpenWebPortal_Click">
                                                <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                                                    <!-- External link symbol -->
                                                    <Path Data="M 10 13 A 5 5 0 0 0 17.54 13.54 L 20.54 10.54 A 5 5 0 0 0 13.47 3.47 L 11.75 5.18 M 14 11 A 5 5 0 0 0 6.46 10.46 L 3.46 13.46 A 5 5 0 0 0 10.53 20.53 L 12.24 18.82" 
                                                          Stroke="{Binding Foreground, RelativeSource={RelativeSource AncestorType=Button}}" StrokeThickness="3" Width="11" Height="11" Stretch="Uniform"/>
                                                    <TextBlock Text="OPEN WEB PORTAL" Margin="5,0,0,0" FontSize="10" FontWeight="ExtraBold"/>
                                                </StackPanel>
                                            </Button>
                                            <TextBlock Text="Login with your bypass key to access premium features" Margin="0,5,0,0" Foreground="{StaticResource TextMutedBrush}" FontSize="8" HorizontalAlignment="Center" TextAlignment="Center" LineHeight="1.4"/>
                                        </StackPanel>
                                    </StackPanel>
                                </Border>
                            </Grid>
'''

new_content += ''.join(lines[596:])

with open('e:/GreatRed/GreatRed/MainWindow.xaml', 'w', encoding='utf-8') as f:
    f.write(new_content)
